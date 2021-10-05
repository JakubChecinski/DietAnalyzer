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
    public class FoodItemRepository : IFoodItemRepository
    {
        private IApplicationDbContext _context;
        private INutritionRepository _nutritionRepository;
        private IRestrictionRepository _restrictionRepository;
        public FoodItemRepository(IApplicationDbContext context, 
            INutritionRepository nutritionRepository , IRestrictionRepository restrictionRepository)
        {
            _context = context;
            _nutritionRepository = nutritionRepository;
            _restrictionRepository = restrictionRepository;
        }
        public IEnumerable<FoodItemViewModel> Get(string userId)
        {
            var foods = _context.FoodItems
                .Where(x => x.UserId == userId || x.UserId == null)
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures);
            return foods.ToList()
                .Select(x => new FoodItemViewModel
                {
                    Name = x.Name,
                    Nutrition = x.Nutrition,
                    Restrictions = x.Restrictions,
                    Measures = x.Measures,
                });
        }

        public IEnumerable<FoodItemViewModel> Get(string userId, string foodName)
        {
            var foods = _context.FoodItems
                .Where(x => (x.UserId == userId || x.UserId == null) && x.Name == foodName)
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures);
            return foods.ToList()
                .Select(x => new FoodItemViewModel
                {
                    Name = x.Name,
                    Nutrition = x.Nutrition,
                    Restrictions = x.Restrictions,
                    Measures = x.Measures,
                });
        }

        public FoodItem Get(string userId, int foodId)
        {
            return _context.FoodItems
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures)
                .Single(x => (x.UserId == userId || x.UserId == null) && x.Id == foodId);
        }

        public void Add(FoodItem food)
        {
            _context.FoodItems.Add(food);
            _context.RestrictionsInfos.Add(food.Restrictions);
            _nutritionRepository.Add(food.Nutrition);
            _restrictionRepository.Add(food.Restrictions);
        }

        public void Update(FoodItem food, string userId)
        {
            var foodToUpdate = _context.FoodItems.Single(x => x.Id == food.Id && x.UserId == userId);
            foodToUpdate.Name = food.Name;
            _nutritionRepository.Update(food.Nutrition);
            _restrictionRepository.Update(food.Restrictions);
        }

        public void Delete(int foodId, string userId)
        {
            var foodToDelete = _context.FoodItems.Single(x => x.Id == foodId && x.UserId == userId);
            _context.FoodItems.Remove(foodToDelete);
        }
        
    }
}
