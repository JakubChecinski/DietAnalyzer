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

        public Measure Get(int measureId)
        {
            return _unitOfWork.Measures.Get(measureId);
        }

        public IEnumerable<Measure> GetCustom(string userId)
        {
            return _unitOfWork.Measures.GetCustom(userId);
        }

        public void Update(IEnumerable<Measure> newMeasures, string userId)
        {
            var newMeasuresList = newMeasures.ToList();
            var oldMeasures = _unitOfWork.Measures.GetCustom(userId);
            if (oldMeasures != null)
                foreach (Measure oldMeasure in oldMeasures)
                {
                    if(newMeasuresList.Any(x => x.Id == oldMeasure.Id))
                    {
                        newMeasuresList.RemoveAll(x => x.Id == oldMeasure.Id);
                        continue;
                    }
                    foreach (var foodMeasure in oldMeasure.FoodItems)
                        _unitOfWork.FoodMeasures.Delete(foodMeasure.Id);
                    foreach (var dietItem in oldMeasure.DietItems)
                        _unitOfWork.DietItems.Delete(dietItem);
                    _unitOfWork.Measures.Delete(oldMeasure.Id, userId);
                }
            if (newMeasuresList != null)
                foreach (Measure newMeasure in newMeasuresList)
                {
                    _unitOfWork.Measures.Add(newMeasure);
                    _unitOfWork.Save();
                    foreach (var foodItem in _unitOfWork.Foods.Get(userId))
                    {
                        _unitOfWork.FoodMeasures.Add(newMeasure.Id, foodItem.Id);
                    }
                }
            _unitOfWork.Save();
        }

    }
}
