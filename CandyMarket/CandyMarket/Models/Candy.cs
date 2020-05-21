using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Models
{
    public class Candy
    {
        public int candyId { get; set; }
        public string candyName { get; set; }
        public string manufacturer { get; set; }
        public string flavorCategory { get; set; }

        public Candy(string CandyName, string Manufacturer, string FlavorCategory)
        {
            candyName = CandyName;
            manufacturer = Manufacturer;
            flavorCategory = FlavorCategory;

        }
    }
}
