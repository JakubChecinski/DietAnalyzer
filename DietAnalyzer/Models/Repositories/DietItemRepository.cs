using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public class DietItemRepository : IDietItemRepository
    {
        private IApplicationDbContext _context;
        public DietItemRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<DietItem> Get(int dietId)
        {
            var dietItems = _context.DietItems
                .Where(x => x.DietId == dietId)
                .Include(x => x.Measure)
                .Include(x => x.MeasureId)
                .Include(x => x.FoodItem)
                .Include(x => x.FoodItemId);
            return dietItems.ToList();
        }
        public void Add(DietItem dietItem)
        {
            _context.DietItems.Add(dietItem);
        }

        public void Delete(DietItem dietItem)
        {
            var itemToDelete = _context.DietItems.Single(x => x.Id == dietItem.Id);
            _context.DietItems.Remove(itemToDelete);
        }
    }
}
