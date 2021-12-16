using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// A repository for Nutrition tables used in FOODS. Don't call it for Nutrition tables used in diets. 
    /// Methods: add, update
    /// 
    /// </summary>
    public interface INutritionFoodRepository
    {
        void Add(NutritionFood nutrition);
        Task AddAsync(NutritionFood nutrition);
        void Update(NutritionFood nutrition);
    }
}
