using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class DietViewModel
    {
        public bool IsAdd { get; set; }
        public bool NoFoodsOnList { get; set; }
        public Diet Diet { get; set; }
        public List<DietItem> DietItems { get; set; } 
        public List<FoodItem> AvailableFoods { get; set; }
        public List<List<Tuple<int, string>>>  AvailableMeasuresForEachFood { get; set; }
        public int? CurrentFoodId { get; set; }
        public string PositionsToDelete { get; set; }
    }
}
