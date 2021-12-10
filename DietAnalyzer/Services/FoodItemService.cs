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
        private IMeasureService _measureService;
        private IRestrictionService _restrictionService;
        public FoodItemService(IUnitOfWork unitOfWork, 
            IMeasureService measureService, IRestrictionService restrictionService)
        {
            _unitOfWork = unitOfWork;
            _restrictionService = restrictionService;
            _measureService = measureService;
        }

        public IEnumerable<FoodItem> Get(string userId, bool suitableOnly = false)
        {
            if (suitableOnly)
            {
                var userRestrictions = _restrictionService.Get(userId);
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
        public List<List<Tuple<int, string>>> PrepareMeasuresForFoods(string userId, 
            ICollection<DietItem> dietItems)
        {
            var availableMeasures = new List<List<Tuple<int, string>>>();
            for (int i = 0; i < dietItems.Count; i++)
            {
                availableMeasures.Add(PrepareMeasuresForFood(userId, 
                    dietItems.ElementAt(i).FoodItemId));
            }
            return availableMeasures;
        }
        public List<Tuple<int, string>> PrepareMeasuresForFood(string userId, int foodId)
        {
            var availableMeasures = new List<Tuple<int, string>>();
            var currentFood = Get(userId, foodId);
            foreach (var measure in currentFood.Measures)
            {
                if (measure.IsCurrentlyLinked)
                    availableMeasures.Add
                        (new Tuple<int, string>(measure.MeasureId, measure.Measure.Name));
            }
            return availableMeasures;
        }

        public FoodItem Get(string userId, int foodId)
        {
            return _unitOfWork.Foods.Get(userId, foodId);
        }

        public FoodItem PrepareNewFood(string userId)
        {
            var newFood = new FoodItem
            {
                Name = "",
                UserId = userId,
                Nutrition = new NutritionFood(),
                Restrictions = new RestrictionFood(),
            };
            newFood.Nutrition.FoodItem = newFood;
            newFood.Restrictions.FoodItem = newFood;
            var availableMeasures = _measureService.Get(userId);
            foreach (Measure measure in availableMeasures)
            {
                newFood.Measures.Add(new FoodMeasure
                {
                    IsCurrentlyLinked = measure.Id == 1 ? true : false,
                    FoodItemId = 0,
                    Measure = measure,
                    MeasureId = measure.Id,
                });
            }
            return newFood;
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
