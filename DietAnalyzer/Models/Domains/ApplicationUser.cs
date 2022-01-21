using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
