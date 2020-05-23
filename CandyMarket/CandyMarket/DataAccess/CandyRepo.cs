using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
<<<<<<< HEAD
using Dapper;
=======
using CandyMarket.Models;
using Dapper;
using System.Data.SqlClient;
>>>>>>> e009ec2c0bb891fde60502bdd4c8b2194c10af6f

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
        static List<Candy> _candy = new List<Candy>()
        {
            new Candy()
            {
                CandyName = "Snickers",
                Manufacturer = "Mars, Inc.",
                FlavorCategory = "Chocolate",
            };

        public List<Candy> GetAll()
        {
            // Dappper
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Candy>("select * from candy").ToList();
            }

            public GetById(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var idQuery = @"";
                var candy = db.QueryFirstOrDefault<Candy>(idQuery, new { Id = id });
                return candy;
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
>>>>>>> e009ec2c0bb891fde60502bdd4c8b2194c10af6f
            }
        }
    }
}
