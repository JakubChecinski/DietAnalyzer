using Microsoft.AspNetCore.Identity;
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
        public RestrictionUser Restrictions { get; set; }
        public ApplicationUser()
        {
            Measures = new Collection<Measure>();
            Foods = new Collection<FoodItem>();
        }
    }
}
