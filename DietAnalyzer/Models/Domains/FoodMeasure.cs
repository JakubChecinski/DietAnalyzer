using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// This is an (almost) purely technical class 
    /// Used to represent the many-to-many relationship between FoodItem and Measure (basically, a join table)
    /// 
    /// The only addition is an extra boolean field to keep track of links between foods and measures
    /// Because while most foods will typically only use SOME measures,
    /// they still need to be aware of ALL measures, in case the user changes their mind
    /// So we need to represent both the food-measure links that are currently active 
    /// and the ones that are currently inactive.
    /// 
    /// </summary>
    public class FoodMeasure
    {
        [Key]
        public int Id { get; set; }

        public bool IsCurrentlyLinked { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
    }
}
