using DietAnalyzer.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    public interface IEvaluationService
    {
        NutritionDiet GetNutritions(Diet diet);
        List<EvaluationResult> GetSummary(Diet diet);
    }
}
