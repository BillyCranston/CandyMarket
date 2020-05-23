using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CandyMarket.Models;
using Dapper;
using System.Data.SqlClient;


namespace CandyMarket.DataAccess
{
    public class CandyRepo
    {
        string connectionString;

        public CandyRepo(IConfiguration config)
        {
            connectionString = config.GetConnectionString("CandyMarket");
        }

        public IEnumerable<Candy> GetByUserId(int userId)
        {
            var sql = @"
                        select candies.CandyId, candies.CandyName, Candies.Manufacturer, candies.FlavorCategory
                        from UserCandies
	                        join candies
		                        on candies.candyid = usercandies.candyid
                        where usercandies.userid = @userId
                        and userCandies.isConsumed = 0;
                      ";


            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new { UserId = userId };

                var candies = db.Query<Candy>(sql, parameters);

                return candies;
            }
        }

        public User GetUserById(int userId)
        {
            var sql = @"
                        select *
                        from users
                        where userid = @UserId;
                      ";

            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new { UserId = userId };
                var user = db.QueryFirstOrDefault<User>(sql, parameters);
                return user;
            }
        }

        public UserCandyView EatCandy(int userCandyId)
        {
            var sql = @"update UserCandies
                        set isConsumed = 1
                        where userCandyId = @UserCandyId
                        select uc.*, c.CandyName, c.FlavorCategory
                        from UserCandies uc
                            join Candies c
                            on uc.CandyId = c.CandyId
                        where uc.UserCandyId = @UserCandyId";

            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new { UserCandyId = userCandyId };
                var candyConsumed = db.QueryFirstOrDefault<UserCandyView>(sql, parameters);
                return candyConsumed;
            }
        }

        public UserCandyView ConsumeSpecificCandy(int candyId, int userId)
        {
            var sql = @"select UserCandyId
                        from UserCandies
                        where isConsumed = 0
                        and candyId = @CandyId
                        and userId = @UserId
                        order by dateReceived";
            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new
                {
                    CandyId = candyId,
                    UserId = userId
                };
                var CandyToConsume = db.QueryFirstOrDefault<int>(sql, parameters);
                var eatenCandy = EatCandy(CandyToConsume);
                return eatenCandy;
            }
        }

    }
}
