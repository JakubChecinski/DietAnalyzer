using DietAnalyzer.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// Standard implementation of IDietItemRepository
    /// 
    /// </summary>
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
                .Where(x => x.DietId == dietId);
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
