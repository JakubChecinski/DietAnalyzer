using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    /// <summary>
    /// A helper viewModel for a new row in the table of diet items,
    /// used only for an Ajax trick to dynamically update the table
    /// </summary>
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
