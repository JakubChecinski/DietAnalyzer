using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// this is a purely technical class 
    /// used to represent the many-to-many relationship between FoodItem and Diet
    /// (a join table)
    /// 
    /// </summary>
    public class FoodDietRecommendation
    {
        [Key]
        public int Id { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public int DietId { get; set; }
        public Diet Diet { get; set; }

    }
}
