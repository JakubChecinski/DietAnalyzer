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

        public RestrictionsInfo Get(string userId)
        {
            var restrictions = _unitOfWork.Restrictions.Get(userId);
            if (restrictions != null) return restrictions;
            var newRestrictions = new RestrictionsInfo
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
            _unitOfWork.Restrictions.Add(newRestrictions);
            _unitOfWork.Save();
            return newRestrictions;
        }

        public void Update(RestrictionsInfo restriction)
        {
            _unitOfWork.Restrictions.Update(restriction);
            _unitOfWork.Save();
        }

    }
}
