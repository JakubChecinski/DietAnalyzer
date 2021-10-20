using DietAnalyzer.Models.DataAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{

    /// note about yes/no conventions
    /// 
    /// convention for FOODS is as following:
    /// true - suitable for this category, false - not suitable for this category, e.g.:
    /// Vegetarian = true       // this product is suitable for vegetarians
    /// Diabetes = true         // this product is suitable for people with diabetes
    /// KidneyProblems = false  // this product is not suitable for people with kidney conditions
    /// 
    /// convention for PEOPLE is as following:
    /// true - restriction applies, false - restriction does not apply, e.g.:
    /// Vegetarian = true       // this person is a vegetarian
    /// Diabetes = true         // this person has diabetes 
    /// KidneyProblems = false  // this person does not have kidney problems  
    /// 
    /// a simple consequence is the rule for matching people and products:
    /// IF Person.Vegetarian is TRUE, then Product.Vegetarian must also be TRUE
    /// IF Person.Vegetarian is FALSE, then Product.Vegetarian does not matter

    public class Restriction
    {

        [DefaultValue(true)]
        public bool Pescetarian { get; set; }  // foods: IF product is land animal meat THEN false, ELSE true

        [DefaultValue(true)]
        [LTELogicalConjunction("Pescetarian")]
        public bool Vegetarian { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Dairy Intolerant")]
        public bool DairyIntolerant { get; set; }  

        [DefaultValue(true)]
        [LTELogicalConjunction("Pescetarian", "Vegetarian", "DairyIntolerant")]
        public bool Vegan { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Gluten Intolerant")]
        public bool GlutenIntolerant { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Paleo Diet")]
        public bool Paleo { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Keto Diet")]
        public bool Keto { get; set; }

        [DefaultValue(true)]
        public bool Diabetes { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Heart Problems")]
        public bool HeartProblems { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Kidney Problems")]
        public bool KidneyProblems { get; set; }

    }
}
