using DietAnalyzer.Models.Domains;
using System.Collections.Generic;

namespace DietAnalyzer.Models.ViewModels
{
    /// <summary>
    /// A viewModel for the list of all diets belonging to the current user
    /// </summary>
    public class DietListViewModel
    {
        public IEnumerable<Diet> Diets { get; set; }
        public IEnumerable<int> IncompatibleDietIds { get; set; }
    }
}
