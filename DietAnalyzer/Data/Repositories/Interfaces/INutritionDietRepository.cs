using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// A repository for Nutrition tables used in DIETS. Don't call it for Nutrition tables used in foods. 
    /// Methods: add, update
    /// 
    /// </summary>
    public interface INutritionDietRepository
    {
        void Add(NutritionDiet nutrition);
        void Update(NutritionDiet nutrition);
    }
}
