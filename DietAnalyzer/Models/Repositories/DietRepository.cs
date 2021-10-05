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
        private INutritionRepository _nutritionRepository;
        public DietRepository(IApplicationDbContext context, INutritionRepository nutritionRepository)
        {
            _context = context;
            _nutritionRepository = nutritionRepository;
        }

        public IEnumerable<DietViewModel> Get(string userId)
        {
            var diets = _context.Diets
                .Where(x => x.UserId == userId)
                .Include(x => x.Recommendations)
                .Include(x => x.DietItems)
                .Include(x => x.Nutritions);
            return diets.ToList()
                .Select(x => new DietViewModel
                {
                    Name = x.Name,
                    Recommendations = x.Recommendations,
                    DietItems = x.DietItems,
                    Nutritions = x.Nutritions,
                });
        }

        public IEnumerable<DietViewModel> Get(string userId, string dietName)
        {
            var diets = _context.Diets
                .Where(x => x.UserId == userId && x.Name == dietName)
                .Include(x => x.Recommendations)
                .Include(x => x.DietItems)
                .Include(x => x.Nutritions);
            return diets.ToList()
                .Select(x => new DietViewModel
                {
                    Name = x.Name,
                    Recommendations = x.Recommendations,
                    DietItems = x.DietItems,
                    Nutritions = x.Nutritions,
                });
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
            foreach (var dietItem in diet.DietItems)
            {
                _context.DietItems.Add(dietItem);
            }
            _nutritionRepository.Add(diet.Nutritions);
        }

        public void Update(Diet diet, string userId)
        {
            var dietToUpdate = _context.Diets.Single(x => x.Id == diet.Id && x.UserId == userId);
            dietToUpdate.Name = diet.Name;
            foreach(var dietItem in dietToUpdate.DietItems)
            {
                var itemToUpdate = _context.DietItems.Single(x => x.Id == dietItem.Id);
                itemToUpdate.Quantity = dietItem.Quantity;
                itemToUpdate.MeasureId = dietItem.MeasureId;
                itemToUpdate.FoodItemId = dietItem.FoodItemId;
                itemToUpdate.DietId = diet.Id;
            }
            _nutritionRepository.Update(diet.Nutritions);
        }

        public void Delete(int dietId, string userId)
        {
            var dietToDelete = _context.Diets.Single(x => x.Id == dietId && x.UserId == userId);
            _context.Diets.Remove(dietToDelete);
        }

    }
}
