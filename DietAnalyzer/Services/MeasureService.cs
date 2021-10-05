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

        public IEnumerable<MeasureViewModel> Get(string userId)
        {
            return _unitOfWork.Measures.Get(userId);
        }

        public Measure Get(string userId, int measureId)
        {
            return _unitOfWork.Measures.Get(userId, measureId);
        }

        public void Add(Measure measure)
        {
            _unitOfWork.Measures.Add(measure);
            _unitOfWork.Save();
        }

        public void Update(Measure measure, string userId)
        {
            _unitOfWork.Measures.Update(measure, userId);
            _unitOfWork.Save();
        }

        public void Delete(int measureId, string userId)
        {
            _unitOfWork.Measures.Delete(measureId, userId);
            _unitOfWork.Save();
        }

    }
}
