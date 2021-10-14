using DietAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public class FoodDietRecommendationRepository : IFoodDietRecommendationRepository
    {
        private IApplicationDbContext _context;
        public FoodDietRecommendationRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(int recommendationId)
        {
            var fmToDelete = _context.FoodDietRecommendations.Single(x => x.Id == recommendationId);
            _context.FoodDietRecommendations.Remove(fmToDelete);
        }
    }
}
