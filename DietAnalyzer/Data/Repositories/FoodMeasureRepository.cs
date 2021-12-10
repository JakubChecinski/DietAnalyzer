using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
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
            var fmToAdd = new FoodMeasure
            {
                MeasureId = measureId,
                FoodItemId = foodId,
            };
            _context.FoodMeasures.Add(fmToAdd);
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
