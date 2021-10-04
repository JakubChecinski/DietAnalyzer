using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class DietViewModel
    {
        public string Name { get; set; }
        public IEnumerable<DietItem> DietItems { get; set; }
        public IEnumerable<FoodDietRecommendation> Recommendations { get; set; }
        public NutritionInfo Nutritions { get; set; }
    }
}
