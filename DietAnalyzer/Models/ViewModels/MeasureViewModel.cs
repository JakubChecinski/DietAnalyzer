using DietAnalyzer.Models.Domains;
using System.Collections.Generic;

namespace DietAnalyzer.Models.ViewModels
{
    /// <summary>
    /// A viewModel for the list of all measures belonging to the current user
    /// </summary>
    public class MeasureViewModel
    {
        public List<Measure> Measures { get; set; }
        public string PositionsToDelete { get; set; }

    }
}
