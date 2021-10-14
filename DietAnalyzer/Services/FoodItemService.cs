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

        public IEnumerable<FoodItem> Get(string userId)
        {
            return _unitOfWork.Foods.Get(userId);
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
            foreach(var fm in food.Measures) _unitOfWork.FoodMeasures.Update(fm);
            _unitOfWork.Save();
        }

        public void Delete(int foodId, string userId)
        {
            var foodToDelete = _unitOfWork.Foods.Get(userId, foodId);
            foreach (var foodMeasure in foodToDelete.Measures)
                _unitOfWork.FoodMeasures.Delete(foodMeasure.Id);
            foreach (var recommendation in foodToDelete.Recommendations)
                _unitOfWork.Recommendations.Delete(recommendation.Id);
            _unitOfWork.Foods.Delete(foodId, userId);
            _unitOfWork.Save();
        }

    }
}
