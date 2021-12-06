using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class DietItemRowViewModel
    {
        public int Index { get; set; }
        public int DietId { get; set; }
        public int FoodItemId { get; set; }
        public string FoodItemName { get; set; }
        public string FoodItemImageUrl { get; set; }
        public List<Tuple<int, string>> AvailableMeasuresForThisFood { get; set; }
    }
}
