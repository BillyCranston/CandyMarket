using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Models
{
    public class Candy
    {
        public int CandyId { get; set; }
        public string CandyName { get; set; }
        public string Manufacturer { get; set; }
        public string FlavorCategory { get; set; }

        public Candy(string candyName, string manufacturer, string flavorCategory)
        {
            CandyName = candyName;
            Manufacturer = manufacturer;
            FlavorCategory = flavorCategory;

        }
    }
}
