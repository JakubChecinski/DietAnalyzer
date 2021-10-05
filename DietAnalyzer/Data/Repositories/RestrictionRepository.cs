using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data.Repositories
{
    public class RestrictionRepository : IRestrictionRepository
    {
        private IApplicationDbContext _context;
        public RestrictionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public RestrictionsInfo Get(string userId)
        {
            return _context.RestrictionsInfos
                .Single(x => (x.UserId == userId));
        }

        public void Add(RestrictionsInfo restriction)
        {
            _context.RestrictionsInfos.Add(restriction);
        }

        public void Update(RestrictionsInfo restriction)
        {
            var restrictionToUpdate = _context.RestrictionsInfos.Single(x => x.Id == restriction.Id);
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
