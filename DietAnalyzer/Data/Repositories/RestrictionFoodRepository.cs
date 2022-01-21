using DietAnalyzer.Models.Domains;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    /// <summary>
    /// 
    /// Standard implementation of IRestrictionFoodRepository
    /// 
    /// </summary>
    public class RestrictionFoodRepository : IRestrictionFoodRepository
    {
        private IApplicationDbContext _context;
        public RestrictionFoodRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(RestrictionFood restriction)
        {
            _context.RestrictionsFoods.Add(restriction);
        }

        public async Task AddAsync(RestrictionFood restriction)
        {
            await _context.RestrictionsFoods.AddAsync(restriction);
        }

        public void Update(RestrictionFood restriction)
        {
            var restrictionToUpdate = _context.RestrictionsFoods.Single(x => x.Id == restriction.Id);
            restrictionToUpdate.Pescetarian = restriction.Pescetarian;
            restrictionToUpdate.Vegetarian = restriction.Vegetarian;
            restrictionToUpdate.DairyIntolerant = restriction.DairyIntolerant;
            restrictionToUpdate.Vegan = restriction.Vegan;
            restrictionToUpdate.GlutenIntolerant = restriction.GlutenIntolerant;
            restrictionToUpdate.Paleo = restriction.Paleo;
            restrictionToUpdate.Keto = restriction.Keto;
            restrictionToUpdate.Diabetes = restriction.Diabetes;
            restrictionToUpdate.HeartProblems = restriction.HeartProblems;
            restrictionToUpdate.KidneyProblems = restriction.KidneyProblems;
        }
    }
}
