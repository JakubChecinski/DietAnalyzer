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

        public IEnumerable<DietViewModel> Get(string userId)
        {
            return _unitOfWork.Diets.Get(userId);
        }

        public IEnumerable<DietViewModel> Get(string userId, string dietName)
        {
            return _unitOfWork.Diets.Get(userId, dietName);
        }

        public Diet Get(string userId, int dietId)
        {
            return _unitOfWork.Diets.Get(userId, dietId);
        }

        public void Add(Diet diet)
        {
            _unitOfWork.Diets.Add(diet);
            _unitOfWork.Save();
        }

        public void Update(Diet diet, string userId)
        {
            _unitOfWork.Diets.Update(diet, userId);
            _unitOfWork.Save();
        }

        public void Delete(int dietId, string userId)
        {
            _unitOfWork.Diets.Delete(dietId, userId);
            _unitOfWork.Save();
        }


    }
}
