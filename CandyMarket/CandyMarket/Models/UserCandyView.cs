using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Models
{
    public class UserCandyView
    {
        public int UserCandyId { get; set; }
        public int CandyId { get; set; }
        public int UserId { get; set; }
        public DateTime DateReceived { get; set; }
        public bool isConsumed { get; set; }
        public string CandyName { get; set; }
        public string FlavorCategory { get; set; }
    }
}
