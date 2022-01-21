using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.Domains
{
    public class NutritionFood : Nutrition
    {
        [Key]
        public int Id { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

    }
}
