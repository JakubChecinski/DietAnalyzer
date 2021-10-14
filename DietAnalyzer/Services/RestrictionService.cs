using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public class RestrictionService : IRestrictionService
    {
        private IUnitOfWork _unitOfWork;
        public RestrictionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RestrictionUser Get(string userId)
        {
            var restrictions = _unitOfWork.RestrictionUsers.Get(userId);
            if (restrictions != null) return restrictions;
            var newRestrictions = new RestrictionUser
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
            _unitOfWork.RestrictionUsers.Add(newRestrictions);
            _unitOfWork.Save();
            return newRestrictions;
        }

        public void Update(RestrictionUser restriction)
        {
            _unitOfWork.RestrictionUsers.Update(restriction);
            _unitOfWork.Save();
        }

    }
}
