using DietAnalyzer.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    public interface IUnitOfWork
    {
        IDietRepository Diets { get; }
        IDietItemRepository DietItems { get; }
        IFoodItemRepository Foods { get; }
        IFoodDietRecommendationRepository Recommendations { get; }
        IMeasureRepository Measures { get; }
        IFoodMeasureRepository FoodMeasures { get; }
        INutritionDietRepository NutritionDiets { get; }
        INutritionFoodRepository NutritionFoods { get; }
        IRestrictionFoodRepository RestrictionFoods { get; }
        IRestrictionUserRepository RestrictionUsers { get; }
        void Save();

    }
}
