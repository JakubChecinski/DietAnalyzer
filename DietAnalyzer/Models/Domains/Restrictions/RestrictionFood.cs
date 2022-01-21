using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.Domains
{
    public class RestrictionFood : Restriction
    {
        [Key]
        public int Id { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public RestrictionFood()
        {
            Pescetarian = true;
            Vegetarian = true;
            Vegan = true;
            DairyIntolerant = true;
            GlutenIntolerant = true;
            Paleo = true;
            Keto = true;
            Diabetes = true;
            HeartProblems = true;
            KidneyProblems = true;
        }
    }
}
