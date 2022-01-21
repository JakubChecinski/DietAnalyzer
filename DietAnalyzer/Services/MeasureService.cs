using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.Services
{
    /// <summary>
    /// 
    /// A standard implementation of IMeasureService
    /// 
    /// </summary>
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
            var newMeasuresList = newMeasures == null ? null : newMeasures.ToList();
            var oldMeasures = _unitOfWork.Measures.GetCustom(userId);
            if (newMeasuresList != null)
                foreach (Measure newMeasure in newMeasuresList)
                {
                    if (oldMeasures != null && oldMeasures.Any(x => x.Id == newMeasure.Id))
                    {
                        _unitOfWork.Measures.Update(newMeasure, userId);
                    }
                    else
                    {
                        AddMeasureWithLinks(newMeasure, userId);
                    }
                }
            if (oldMeasures != null)
            {
                foreach (Measure oldMeasure in oldMeasures)
                {
                    if (newMeasuresList != null && newMeasuresList.Any(x => x.Id == oldMeasure.Id)) continue;
                    else DeleteMeasureWithLinks(oldMeasure, userId);
                }
            }
            _unitOfWork.Save();
        }

        public List<FoodMeasure> ReloadMeasures(List<FoodMeasure> foodMeasures)
        {
            // I was hoping Entity would do this automatically, but apparently it doesn't
            // Maybe it's because I added a new field to the join FoodMeasure class?
            for (int i = 0; i < foodMeasures.Count; i++)
            {
                foodMeasures[i].Measure = Get(foodMeasures[i].MeasureId);
            }
            return foodMeasures;
        }

        private void AddMeasureWithLinks(Measure measure, string userId)
        {
            _unitOfWork.Measures.Add(measure);
            _unitOfWork.Save();
            foreach (var foodItem in _unitOfWork.Foods.Get(userId))
            {
                _unitOfWork.FoodMeasures.Add(measure.Id, foodItem.Id);
            }
        }

        private void DeleteMeasureWithLinks(Measure measure, string userId)
        {
            foreach (var foodMeasure in measure.FoodItems)
                _unitOfWork.FoodMeasures.Delete(foodMeasure.Id);
            foreach (var dietItem in measure.DietItems)
                _unitOfWork.DietItems.Delete(dietItem);
            _unitOfWork.Measures.Delete(measure.Id, userId);
        }

    }
}
