using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DietAnalyzer.Models.ViewModels
{
    /// <summary>
    /// A viewModel for a food
    /// </summary>
    public class FoodItemViewModel
    {
        public bool IsAdd { get; set; }
        public bool HasImageProblem { get; set; }
        public bool HasMeasureProblem { get; set; }
        public IFormFile ImageFile { get; set; }
        public FoodItem FoodItem { get; set; }
        public List<FoodMeasure> AvailableMeasures { get; set; }
    }
}
