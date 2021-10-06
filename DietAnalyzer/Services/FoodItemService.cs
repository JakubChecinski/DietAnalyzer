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
            _unitOfWork.Restrictions.Add(food.Restrictions);
            _unitOfWork.Nutritions.Add(food.Nutrition);
            _unitOfWork.Save();
        }

        public void Update(FoodItem food, string userId)
        {
            _unitOfWork.Foods.Update(food, userId);
            _unitOfWork.Nutritions.Update(food.Nutrition);
            _unitOfWork.Restrictions.Update(food.Restrictions);
            _unitOfWork.Save();
        }

        public void Delete(int foodId, string userId)
        {
            _unitOfWork.Foods.Delete(foodId, userId);
            _unitOfWork.Save();
        }

    }
}
