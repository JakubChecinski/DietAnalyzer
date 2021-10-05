﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Measure> Measures { get; set; }
        public ICollection<FoodItem> Foods { get; set; }
        public RestrictionsInfo Restrictions { get; set; }
        public ApplicationUser()
        {
            Measures = new Collection<Measure>();
            Foods = new Collection<FoodItem>();
            Restrictions = new RestrictionsInfo
            {
                Pescetarian = false,
                Vegetarian = false,
                DairyIntolerant = false,
                Vegan = false,
                GlutenIntolerant = false,
                Paleo = false,
                Keto = false,
                Diabetes = false,
                HeartProblems = false,
                KidneyProblems = false,
            };
        }
    }
}
