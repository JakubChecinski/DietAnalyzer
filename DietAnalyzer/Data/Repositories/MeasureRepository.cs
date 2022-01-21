using DietAnalyzer.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// Standard implementation of IMeasureRepository
    /// 
    /// </summary>
    public class MeasureRepository : IMeasureRepository
    {
        private IApplicationDbContext _context;
        public MeasureRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Measure> Get(string userId)
        {
            var measures = _context.Measures
                 .Where(x => (x.UserId == userId || x.UserId == null) && x.IsKnownUniversally);
            return measures.ToList();
        }

        public IEnumerable<Measure> GetCustom(string userId)
        {
            var measures = _context.Measures
                 .Where(x => x.UserId == userId && x.IsKnownUniversally)
                 .OrderBy(x => x.Name)
                 .Include(x => x.FoodItems)
                 .Include(x => x.DietItems).AsSplitQuery();
            return measures.ToList();
        }

        public Measure Get(int measureId)
        {
            return _context.Measures.Single(x => x.Id == measureId);
        }

        public void Add(Measure measure)
        {
            _context.Measures.Add(measure);
        }

        public async Task AddAsync(Measure measure)
        {
            await _context.Measures.AddAsync(measure);
        }

        public void Update(Measure measure, string userId)
        {
            var measureToUpdate = _context.Measures.Single(x => x.Id == measure.Id && x.UserId == userId);
            measureToUpdate.Name = measure.Name;
            measureToUpdate.Grams = measure.Grams;
        }

        public void Delete(int measureId, string userId)
        {
            var measureToDelete = _context.Measures.Single(x => x.Id == measureId && x.UserId == userId);
            _context.Measures.Remove(measureToDelete);
        }

    }
}
