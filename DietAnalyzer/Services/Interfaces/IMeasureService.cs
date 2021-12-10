using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    /// <summary>
    /// 
    /// A service for Measures 
    ///
    /// </summary>
    public interface IMeasureService
    {
        /// <summary>
        /// Get the list of all measures 
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>The list of all measures available to the current user.</returns>
        IEnumerable<Measure> Get(string userId);

        /// <summary>
        /// Get a single measure
        /// </summary>
        /// <param name="measureId"> is the measure ID</param>
        /// <returns>A single Measure object, as long as it's accessible to the current user.</returns>
        Measure Get(int measureId);

        /// <summary>
        /// Get the list of all custom measures
        /// </summary>
        /// <param name="userId"> is the current user ID</param>
        /// <returns>The list of all user-defined measures available to the current user. 
        /// Library (pre-defined) measures are not included.</returns>
        IEnumerable<Measure> GetCustom(string userId);

        /// <summary>
        /// Update every item from a list of measures in database
        /// </summary>
        /// <param name="measures"> is the list of measures to update </param>
        /// <param name="userId"> is the current user ID</param>
        void Update(IEnumerable<Measure> measures, string userId);

        /// <summary>
        /// Reassign measures for every item from a list of FoodMeasure join table objects. 
        /// Entity doesn't always do it automatically, which is why this method exists.
        /// </summary>
        /// <param name="foodMeasures"> is the list of FoodMeasure objects that need a Measure reassignment</param>
        /// <returns>The same FoodMeasure objects as input, but after the reassignment.</returns>
        List<FoodMeasure> ReloadMeasures(List<FoodMeasure> foodMeasures);
    }
}
