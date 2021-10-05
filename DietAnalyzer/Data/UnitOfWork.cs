using DietAnalyzer.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public IDietRepository Diets { get; }
        public IFoodItemRepository Foods { get; }
        public IMeasureRepository Measures { get; }
        public INutritionRepository Nutritions { get; }
        public IRestrictionRepository Restrictions { get; }
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Nutritions = new NutritionRepository(context);
            Restrictions = new RestrictionRepository(context);
            Diets = new DietRepository(context, Nutritions);
            Foods = new FoodItemRepository(context, Nutritions, Restrictions);
            Measures = new MeasureRepository(context); 
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
