using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public class FoodItemService : IFoodItemService
    {
        private IUnitOfWork _unitOfWork;
        public FoodItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<FoodItem> Get(string userId, bool suitableOnly = false)
        {
            if (suitableOnly)
            {
                var userRestrictions = _unitOfWork.RestrictionUsers.Get(userId);
                if (userRestrictions == null)
                {
                    userRestrictions = new RestrictionUser
                    {
                        UserId = userId,
                        Pescetarian = false,
                        Vegetarian = false,
                        DairyIntolerant = false,
                        Vegan = false,
                        GlutenIntolerant = false,
                        Paleo = false,
                        Keto = false,
                        Diabetes = false,
                        HeartProblems = false,
                        KidneyProblems = false,
                    };
                    _unitOfWork.RestrictionUsers.Add(userRestrictions);
                    _unitOfWork.Save();
                }
                return _unitOfWork.Foods.Get(userId, userRestrictions);
            }
            return _unitOfWork.Foods.Get(userId);
        }

        public IEnumerable<FoodItem> GetCustom(string userId, bool suitableOnly = false)
        {
            if (suitableOnly)
            {
                var userRestrictions = _unitOfWork.RestrictionUsers.Get(userId);
                return _unitOfWork.Foods.GetCustom(userId, userRestrictions);
            }
            return _unitOfWork.Foods.GetCustom(userId);
        }

        public FoodItem Get(string userId, int foodId)
        {
            return _unitOfWork.Foods.Get(userId, foodId);
        }

        public void Add(FoodItem food)
        {
            _unitOfWork.Foods.Add(food);
            _unitOfWork.RestrictionFoods.Add(food.Restrictions);
            _unitOfWork.NutritionFoods.Add(food.Nutrition);
            _unitOfWork.Save();
        }

        public void Update(FoodItem food, string userId)
        {
            _unitOfWork.Foods.Update(food, userId);
            _unitOfWork.NutritionFoods.Update(food.Nutrition);
            _unitOfWork.RestrictionFoods.Update(food.Restrictions);
            foreach (var fm in food.Measures) _unitOfWork.FoodMeasures.Update(fm);
            _unitOfWork.Save();
        }

        public void Delete(int foodId, string userId)
        {
            var foodToDelete = _unitOfWork.Foods.Get(userId, foodId);
            foreach (var foodMeasure in foodToDelete.Measures)
                _unitOfWork.FoodMeasures.Delete(foodMeasure.Id);
            foreach (var connectedItem in foodToDelete.DietItems)
                _unitOfWork.DietItems.Delete(connectedItem);
            _unitOfWork.Foods.Delete(foodId, userId);
            _unitOfWork.Save();
            CleanUpEmptyDiets(userId);
        }

        private void CleanUpEmptyDiets(string userId)
        {
            foreach (var diet in _unitOfWork.Diets.Get(userId)) 
                if (diet.DietItems.Count == 0) _unitOfWork.Diets.Delete(diet.Id, userId);
            _unitOfWork.Save();
        }

    }
}
