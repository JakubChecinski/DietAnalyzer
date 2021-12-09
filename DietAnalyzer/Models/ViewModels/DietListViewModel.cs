using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
