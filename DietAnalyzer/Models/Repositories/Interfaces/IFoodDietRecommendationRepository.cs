using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public interface IFoodDietRecommendationRepository
    {
        void Delete(int recommendationId);
    }
}
