﻿using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Repositories
{
    public class RestrictionUserRepository : IRestrictionUserRepository
    {
        private IApplicationDbContext _context;
        public RestrictionUserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public RestrictionUser Get(string userId)
        {
            return _context.RestrictionsUsers
                .SingleOrDefault(x => (x.UserId == userId));
        }

        public void Add(RestrictionUser restriction)
        {
            _context.RestrictionsUsers.Add(restriction);
        }

        public void Update(RestrictionUser restriction)
        {
            var restrictionToUpdate = _context.RestrictionsUsers.Single(x => x.Id == restriction.Id);
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