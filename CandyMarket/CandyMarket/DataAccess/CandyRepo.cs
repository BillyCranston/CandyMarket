using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace CandyMarket.DataAccess
{
    public class CandyRepo
    {
        string connectionString;

        public CandyRepo(IConfiguration config)
        {
            connectionString = config.GetConnectionString("CandyMarket");
        }

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
            }
        }
    }
}
