using DietAnalyzer.Data.Repositories;

namespace DietAnalyzer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public IDietRepository Diets { get; }
        public IDietItemRepository DietItems { get; }
        public IFoodItemRepository Foods { get; }
        public IMeasureRepository Measures { get; }
        public IFoodMeasureRepository FoodMeasures { get; }
        public INutritionDietRepository NutritionDiets { get; }
        public INutritionFoodRepository NutritionFoods { get; }
        public IRestrictionFoodRepository RestrictionFoods { get; }
        public IRestrictionUserRepository RestrictionUsers { get; }
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Diets = new DietRepository(context);
            DietItems = new DietItemRepository(context);
            Foods = new FoodItemRepository(context);
            Measures = new MeasureRepository(context);
            FoodMeasures = new FoodMeasureRepository(context);
            NutritionDiets = new NutritionDietRepository(context);
            NutritionFoods = new NutritionFoodRepository(context);
            RestrictionFoods = new RestrictionFoodRepository(context);
            RestrictionUsers = new RestrictionUserRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
