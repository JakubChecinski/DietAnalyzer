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
            return _unitOfWork.Restrictions.Get(userId);
        }

        public void Update(RestrictionsInfo restriction)
        {
            _unitOfWork.Restrictions.Update(restriction);
            _unitOfWork.Save();
        }

    }
}
