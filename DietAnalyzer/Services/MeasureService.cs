using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services
{
    public class MeasureService : IMeasureService
    {
        private IUnitOfWork _unitOfWork;
        public MeasureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Measure> Get(string userId)
        {
            return _unitOfWork.Measures.Get(userId);
        }

        public void Update(IEnumerable<Measure> measures, string userId)
        {
            var userMeasures = _unitOfWork.Measures.GetCustom(userId);
            foreach (Measure measure in userMeasures) _unitOfWork.Measures.Delete(measure.Id, userId);
            foreach (Measure measure in measures) _unitOfWork.Measures.Add(measure);
            _unitOfWork.Save();
        }


    }
}
