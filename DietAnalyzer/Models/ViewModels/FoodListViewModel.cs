using DietAnalyzer.Models.Domains;
using System.Collections.Generic;

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
