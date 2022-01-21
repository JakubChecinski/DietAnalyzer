using DietAnalyzer.Models.DataAttributes;
using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// A domain class representing a single diet item in the format of:
    /// [QUANTITY] [MEASURES] of [FOODITEM]
    /// for example, 2 cups of flour or 15 grams of garlic
    /// 
    /// </summary>
    public class DietItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }

        [Required]
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        [Required]
        public int DietId { get; set; }
        public Diet Diet { get; set; }
    }
}
