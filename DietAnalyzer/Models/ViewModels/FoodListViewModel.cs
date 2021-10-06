using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    public class FoodListViewModel
    {
        public IEnumerable<FoodItem> Foods { get; set; }
    }
}
