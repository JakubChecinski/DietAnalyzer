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
    public class DietRepository : IDietRepository
    {
        private IApplicationDbContext _context;
        public DietRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Diet> Get(string userId)
        {
            var diets = _context.Diets
                .Where(x => x.UserId == userId)
                .Include(x => x.Recommendations)
                .Include(x => x.DietItems)
                .Include(x => x.Nutritions);
            return diets.ToList();
        }

        public Diet Get(string userId, int dietId)
        {
            return _context.Diets
                .Include(x => x.DietItems)
                .Include(x => x.Recommendations)
                .Include(x => x.Nutritions)
                .Single(x => x.UserId == userId && x.Id == dietId);
        }

        public void Add(Diet diet)
        {
            _context.Diets.Add(diet);
        }

        public void Update(Diet diet, string userId)
        {
            var dietToUpdate = _context.Diets.Single(x => x.Id == diet.Id && x.UserId == userId);
            dietToUpdate.Name = diet.Name;
            // DietService takes care of the rest (nutritions and dietItems)
        }

        public void Delete(int dietId, string userId)
        {
            var dietToDelete = _context.Diets.Single(x => x.Id == dietId && x.UserId == userId);
            _context.Diets.Remove(dietToDelete);
        }

    }
}
