using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class RestrictionUser : Restriction
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public RestrictionUser()
        {
            Pescetarian = false;
            Vegetarian = false;
            Vegan = false;
            DairyIntolerant = false;
            GlutenIntolerant = false;
            Paleo = false;
            Keto = false;
            Diabetes = false;
            HeartProblems = false;
            KidneyProblems = false;
        }
    }
}
