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

        public Candy GetByCandyName(string candyName)
        {
            var sql = @"
                        select *
                        from candies
                        where candyname = @CandyName;
                      ";

            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new { CandyName = candyName };
                var existingCandy = db.QueryFirstOrDefault<Candy>(sql, parameters);
                return existingCandy;
            }
        }
        
        //Add: Add a new candy to the candy table, and add a new entry to user candies table
        public Candy Add(int userId, Candy candyToAdd)
        {
            var sql = @"insert into Candies(CandyName, Manufacturer, FlavorCategory)
                        output inserted.*
                        values(@CandyName, @Manufacturer, @FlavorCategory);";

            using (var db = new SqlConnection(connectionString))
            {
                var result = db.QueryFirstOrDefault<Candy>(sql, candyToAdd);
                return result;
            }
        }

        //Update: Updates the users candy inventory (create new usercandies entry for table)
        public UserCandy Update(int userId, int candyId)
        {
            //DateTime dateTime = new DateTime();
            DateTime dateTime = DateTime.Now;
            var sql = @"insert into UserCandies(UserId, CandyId, DateReceived, IsConsumed)
                        output inserted.*
                        values(@UserId, @CandyId, @DateReceived, 0);";

            using (var db = new SqlConnection(connectionString))
            {
                var parameters = new { UserId = userId, CandyId = candyId, DateReceived = dateTime };
                var result = db.QueryFirstOrDefault<UserCandy>(sql, parameters);
                return result;
            }
        }

    }
}
