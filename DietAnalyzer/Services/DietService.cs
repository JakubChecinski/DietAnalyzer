using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public class DietService : IDietService
    {
        private IUnitOfWork _unitOfWork;
        public DietService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Diet> Get(string userId)
        {
            return _unitOfWork.Diets.Get(userId);
        }

        public Diet Get(string userId, int dietId)
        {
            return _unitOfWork.Diets.Get(userId, dietId);
        }

        public void Add(Diet diet)
        {
            _unitOfWork.Diets.Add(diet);
            foreach (var dietItem in diet.DietItems) _unitOfWork.DietItems.Add(dietItem);
            _unitOfWork.Nutritions.Add(diet.Nutritions);
            _unitOfWork.Save();
        }

        public void Update(Diet diet, string userId)
        {
            _unitOfWork.Diets.Update(diet, userId);
            var currentDietItems = _unitOfWork.DietItems.Get(diet.Id);
            foreach (var dietItem in currentDietItems) _unitOfWork.DietItems.Delete(dietItem);
            foreach (var dietItem in diet.DietItems) _unitOfWork.DietItems.Add(dietItem);
            _unitOfWork.Nutritions.Update(diet.Nutritions);
            _unitOfWork.Save();
        }

        public void Delete(int dietId, string userId)
        {
            _unitOfWork.Diets.Delete(dietId, userId);
            _unitOfWork.Save();
        }


    }
}
