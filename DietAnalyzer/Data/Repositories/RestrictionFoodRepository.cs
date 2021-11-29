using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
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
