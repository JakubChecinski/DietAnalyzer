using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class FoodItemViewModel
    {
        public string Name { get; set; }
        public NutritionInfo Nutrition { get; set; }
        public RestrictionsInfo Restrictions { get; set; }
        public IEnumerable<FoodMeasure> Measures { get; set; }
    }
}
