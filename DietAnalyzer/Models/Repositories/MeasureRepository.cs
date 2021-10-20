using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Measure> Get(string userId)
        {
            var measures = _context.Measures
                 .Where(x => x.UserId == userId || x.UserId == null);
            return measures.ToList();
        }

        public IEnumerable<Measure> GetCustom(string userId)
        {
            var measures = _context.Measures
                 .Where(x => x.UserId == userId)
                 .Include(x => x.FoodItems);
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

        public void Delete(int measureId, string userId)
        {
            var measureToDelete = _context.Measures.Single(x => x.Id == measureId && x.UserId == userId);
            _context.Measures.Remove(measureToDelete);
        }
 
    }
}
