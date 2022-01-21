using DietAnalyzer.Models.Domains;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// Standard implementation of IFoodMeasureRepository
    /// 
    /// </summary>
    public class FoodMeasureRepository : IFoodMeasureRepository
    {
        private IApplicationDbContext _context;
        public FoodMeasureRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(int measureId, int foodId)
        {
            if (_context.FoodMeasures.Any(x => x.MeasureId == measureId && x.FoodItemId == foodId))
                throw new ArgumentException("This FoodMeasure already exists in the database");
            var fmToAdd = new FoodMeasure
            {
                MeasureId = measureId,
                FoodItemId = foodId,
            };
            _context.FoodMeasures.Add(fmToAdd);
        }

        public async Task AddAsync(int measureId, int foodId)
        {
            var fmToAdd = new FoodMeasure
            {
                MeasureId = measureId,
                FoodItemId = foodId,
            };
            await _context.FoodMeasures.AddAsync(fmToAdd);
        }

        public void Update(FoodMeasure foodMeasure)
        {
            var fm = _context.FoodMeasures.Single(x => x.Id == foodMeasure.Id);
            fm.IsCurrentlyLinked = foodMeasure.IsCurrentlyLinked;
        }
        public void Delete(int foodMeasureId)
        {
            var fmToDelete = _context.FoodMeasures.Single(x => x.Id == foodMeasureId);
            _context.FoodMeasures.Remove(fmToDelete);
        }
    }
}
