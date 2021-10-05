using DietAnalyzer.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    public interface IUnitOfWork
    {
        IDietRepository Diets { get; }
        IFoodItemRepository Foods { get; }
        IMeasureRepository Measures { get; }
        INutritionRepository Nutritions { get; }
        IRestrictionRepository Restrictions { get; }
        void Save();

    }
}
