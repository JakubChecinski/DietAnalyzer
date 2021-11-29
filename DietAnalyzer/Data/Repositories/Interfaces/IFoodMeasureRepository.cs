using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    public interface IFoodMeasureRepository
    {
        void Add(int measureId, int foodId);
        void Update(FoodMeasure nutrition);
        void Delete(int foodMeasureId);
    }
}
