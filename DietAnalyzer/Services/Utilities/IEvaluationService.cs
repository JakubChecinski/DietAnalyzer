using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    /// <summary>
    /// 
    /// A utility service containing methods for diet evaluation
    ///
    /// </summary>
    public interface IEvaluationService
    {
        /// <summary>
        /// Get nutritional table for a diet
        /// </summary>
        /// <param name="diet"> is the diet</param>
        /// <returns>A NutritionDiet object with complete information about diet nutritions.</returns>
        NutritionDiet GetNutritions(Diet diet);

        /// <summary>
        /// Get a summary of diet recommendations, based on existing nutrional table.
        /// </summary>
        /// <param name="diet"> is the diet with nutritional table to evaluate</param>
        /// <returns>A list of EvaluationResult objects, containing information for the application user.</returns>
        List<EvaluationResult> GetSummary(Diet diet);
    }
}
