using DietAnalyzer.Data.Repositories;

namespace DietAnalyzer.Data
{
    public interface IUnitOfWork
    {
        IDietRepository Diets { get; }
        IDietItemRepository DietItems { get; }
        IFoodItemRepository Foods { get; }
        IMeasureRepository Measures { get; }
        IFoodMeasureRepository FoodMeasures { get; }
        INutritionDietRepository NutritionDiets { get; }
        INutritionFoodRepository NutritionFoods { get; }
        IRestrictionFoodRepository RestrictionFoods { get; }
        IRestrictionUserRepository RestrictionUsers { get; }
        void Save();

    }
}
