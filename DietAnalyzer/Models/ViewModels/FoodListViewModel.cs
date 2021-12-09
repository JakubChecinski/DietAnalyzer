using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.ViewModels
{
    /// <summary>
    /// A viewModel for the list of all foods belonging to the current user
    /// </summary>
    public class FoodListViewModel
    {
        public IEnumerable<FoodItem> Foods { get; set; }
    }
}
