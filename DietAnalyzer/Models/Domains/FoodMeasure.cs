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
    /// used to represent the many-to-many relationship between FoodItem and Measure
    /// (a join table)
    /// 
    /// </summary>
    public class FoodMeasure
    {
        [Key]
        public int Id { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
    }
}
