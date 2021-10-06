using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class FoodItemViewModel
    {
        public bool IsAdd { get; set; }
        public FoodItem FoodItem { get; set; }
        public IEnumerable<FoodMeasure> AvailableMeasures { get; set; }
    }
}
