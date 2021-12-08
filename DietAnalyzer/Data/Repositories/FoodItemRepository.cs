using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private IApplicationDbContext _context;
        public FoodItemRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<FoodItem> Get(string userId)
        {
            var foods = _context.FoodItems
                .Where(x => x.UserId == userId || x.UserId == null)
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures);
            return foods.ToList();
        }
        public IEnumerable<FoodItem> Get(string userId, RestrictionUser restrictions)
        {
            var foods = _context.FoodItems
                .Where(x => x.UserId == userId || x.UserId == null)
                .Where(x => !restrictions.Pescetarian || x.Restrictions.Pescetarian)
                .Where(x => !restrictions.Vegetarian || x.Restrictions.Vegetarian)
                .Where(x => !restrictions.DairyIntolerant || x.Restrictions.DairyIntolerant)
                .Where(x => !restrictions.Vegan || x.Restrictions.Vegan)
                .Where(x => !restrictions.GlutenIntolerant || x.Restrictions.GlutenIntolerant)
                .Where(x => !restrictions.Paleo || x.Restrictions.Paleo)
                .Where(x => !restrictions.Keto || x.Restrictions.Keto)
                .Where(x => !restrictions.Diabetes || x.Restrictions.Diabetes)
                .Where(x => !restrictions.HeartProblems || x.Restrictions.HeartProblems)
                .Where(x => !restrictions.KidneyProblems || x.Restrictions.KidneyProblems)
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures);
            return foods.ToList();
        }
        public IEnumerable<FoodItem> GetCustom(string userId)
        {
            var foods = _context.FoodItems
                .Where(x => x.UserId == userId)
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures);
            return foods.ToList();
        }
        public IEnumerable<FoodItem> GetCustom(string userId, RestrictionUser restrictions)
        {
            var foods = _context.FoodItems
                .Where(x => x.UserId == userId)
                .Where(x => !restrictions.Pescetarian || x.Restrictions.Pescetarian)
                .Where(x => !restrictions.Vegetarian || x.Restrictions.Vegetarian)
                .Where(x => !restrictions.DairyIntolerant || x.Restrictions.DairyIntolerant)
                .Where(x => !restrictions.Vegan || x.Restrictions.Vegan)
                .Where(x => !restrictions.GlutenIntolerant || x.Restrictions.GlutenIntolerant)
                .Where(x => !restrictions.Paleo || x.Restrictions.Paleo)
                .Where(x => !restrictions.Keto || x.Restrictions.Keto)
                .Where(x => !restrictions.Diabetes || x.Restrictions.Diabetes)
                .Where(x => !restrictions.HeartProblems || x.Restrictions.HeartProblems)
                .Where(x => !restrictions.KidneyProblems || x.Restrictions.KidneyProblems)
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.Measures);
            return foods.ToList();
        }

        public FoodItem Get(string userId, int foodId)
        {
            return _context.FoodItems
                .Include(x => x.Nutrition)
                .Include(x => x.Restrictions)
                .Include(x => x.DietItems)
                .Include(x => x.Measures)
                .ThenInclude(m => m.Measure)
                .Single(x => (x.UserId == userId || x.UserId == null) && x.Id == foodId);
        }

        public void Add(FoodItem food)
        {
            _context.FoodItems.Add(food);
        }

        public void Update(FoodItem food, string userId)
        {
            var foodToUpdate = _context.FoodItems.Single(x => x.Id == food.Id && x.UserId == userId);
            foodToUpdate.Name = food.Name;
            foodToUpdate.ImageFromUser = food.ImageFromUser;
            foodToUpdate.ImageFromApp = food.ImageFromApp;
            // FoodItemService takes care of the rest (nutritions and restrictions)
        }

        public void Delete(int foodId, string userId)
        {
            var foodToDelete = _context.FoodItems.Single(x => x.Id == foodId && x.UserId == userId);
            _context.FoodItems.Remove(foodToDelete);
        }
        
    }
}
