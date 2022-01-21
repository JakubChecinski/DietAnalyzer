using DietAnalyzer.Models.Domains;

namespace DietAnalyzer.Models.ViewModels
{
    /// <summary>
    /// A viewModel for the list of all restrictions belonging to the current user
    /// </summary>

    /// <remarks>
    /// This class is pretty trivial, but I'm keeping it for symmetry and for easier modifications in the future
    /// </remarks>
    public class RestrictionViewModel
    {
        public RestrictionUser RestrictionInfo { get; set; }
    }
}
