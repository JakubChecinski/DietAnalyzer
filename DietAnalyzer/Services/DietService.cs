using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.Services
{
    /// <summary>
    /// 
    /// A standard implementation of IDietService
    /// 
    /// </summary>
    public class DietService : IDietService
    {
        private IUnitOfWork _unitOfWork;
        private IFoodItemService _foodService;
        public DietService(IUnitOfWork unitOfWork, IFoodItemService foodService)
        {
            _unitOfWork = unitOfWork;
            _foodService = foodService;
        }

        public IEnumerable<Diet> Get(string userId)
        {
            return _unitOfWork.Diets.Get(userId);
        }
        public IEnumerable<int> GetIncompatibleDietIds(string userId)
        {
            var incompatibleDietIds = new List<int>();
            foreach (var diet in _unitOfWork.Diets.Get(userId))
            {
                if (CheckCompatibilityWithCurrentRestrictions(diet, userId)) continue;
                else incompatibleDietIds.Add(diet.Id);
            }
            return incompatibleDietIds;
        }

        public Diet Get(string userId, int dietId)
        {
            return _unitOfWork.Diets.Get(userId, dietId);
        }

        public Diet GetWithDietItemChildren(string userId, int dietId)
        {
            return _unitOfWork.Diets.GetWithDietItemChildren(userId, dietId);
        }

        public Diet PrepareNewDiet(string userId)
        {
            var newDiet = new Diet
            {
                Name = "",
                UserId = userId,
                Nutritions = new NutritionDiet(),
            };
            newDiet.Nutritions.Diet = newDiet;
            return newDiet;
        }

        public void Add(Diet diet)
        {
            if (diet == null) throw new ArgumentNullException("Diet to add is null!");
            EnsureUniqueName(diet, diet.UserId);
            _unitOfWork.Diets.Add(diet);
            _unitOfWork.Save();
        }

        public void Update(Diet diet, string userId, bool updateItems = true)
        {
            if (diet == null) throw new ArgumentNullException("Diet to update is null!");
            EnsureUniqueName(diet, userId);
            _unitOfWork.Diets.Update(diet, userId);
            if (updateItems)
            {
                var currentDietItems = _unitOfWork.DietItems.Get(diet.Id);
                foreach (var dietItem in currentDietItems) _unitOfWork.DietItems.Delete(dietItem);
                foreach (var dietItem in diet.DietItems) _unitOfWork.DietItems.Add(dietItem);
            }
            _unitOfWork.Save();
        }

        public void Delete(int dietId, string userId)
        {
            _unitOfWork.Diets.Delete(dietId, userId);
            _unitOfWork.Save();
        }

        private bool CheckCompatibilityWithCurrentRestrictions(Diet diet, string userId)
        {
            var compatibleFoodIds = _foodService.Get(userId, true).Select(x => x.Id);
            foreach (var dietItem in diet.DietItems)
            {
                if (!compatibleFoodIds.Contains(dietItem.FoodItemId)) return false;
            }
            return true;
        }

        public void AssignDietItems(DietViewModel vm)
        {
            foreach (var dietItem in vm.DietItems) dietItem.FoodItem = null;
            vm.Diet.DietItems = vm.DietItems;
        }

        private void EnsureUniqueName(Diet diet, string userId)
        {
            if(_unitOfWork.Diets.Get(userId)
                .Where(x => x.Name == diet.Name && x.Id != diet.Id).Count() == 0) return;
            var i = 2;
            string nameCandidate;
            do
            {
                nameCandidate = diet.Name + " (" + i + ")";
                i++;
            } while(_unitOfWork.Diets.Get(userId)
                .Where(x => x.Name == nameCandidate && x.Id != diet.Id).Count() != 0);
            diet.Name = nameCandidate;
        }

    }
}
