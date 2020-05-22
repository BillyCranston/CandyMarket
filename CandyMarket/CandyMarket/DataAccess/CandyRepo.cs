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
	                        join Users
		                        on users.userId = usercandies.userid
	                        join candies
		                        on candies.candyid = usercandies.candyid
                        where usercandies.userid = @userId;
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
    }
}
