using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CandyMarket.Models;
using Dapper;
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

<<<<<<< HEAD
        public Candy EatCandy(int userCandyId)
        {
            var sql = @"update UserCandies
                        set isConsumed = 1
                        output Inserted.*
                        where userCandyId = @UserCandyId";

            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new { UserCandyId = userCandyId };
                var candyConsumed = db.QueryFirstOrDefault<Candy>(sql, parameters);
                return candyConsumed;
            }
        }

        public Candy ConsumeSpecificCandy(int candyId, int userId)
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
=======
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
>>>>>>> master
            }
        }
    }
}
