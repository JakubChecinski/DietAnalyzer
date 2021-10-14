using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class NutritionFood : NutritionInfo
    {
        [Key]
        public int Id { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

    }
}
