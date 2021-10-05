using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        private IApplicationDbContext _context;
        public MeasureRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<MeasureViewModel> Get(string userId)
        {
            var measures = _context.Measures
                 .Where(x => x.UserId == userId || x.UserId == null);
            return measures.ToList()
                .Select(x => new MeasureViewModel
                {
                    Name = x.Name,
                    Grams = x.Grams,
                });
        }

        public Measure Get(string userId, int measureId)
        {
            return _context.Measures
                .Single(x => (x.UserId == userId || x.UserId == null) && x.Id == measureId);
        }

        public void Add(Measure measure)
        {
            _context.Measures.Add(measure);
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
