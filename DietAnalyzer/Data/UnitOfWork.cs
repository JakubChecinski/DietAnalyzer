using DietAnalyzer.Models.Repositories;
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
        public IDietItemRepository DietItems { get; }
        public IFoodItemRepository Foods { get; }
        public IMeasureRepository Measures { get; }
        public INutritionRepository Nutritions { get; }
        public IRestrictionRepository Restrictions { get; }
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Nutritions = new NutritionRepository(context);
            Restrictions = new RestrictionRepository(context);
            Diets = new DietRepository(context);
            DietItems = new DietItemRepository(context);
            Foods = new FoodItemRepository(context);
            Measures = new MeasureRepository(context); 
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
