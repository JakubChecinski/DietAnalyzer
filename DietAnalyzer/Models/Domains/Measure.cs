using DietAnalyzer.Models.DataAttributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// A simple domain class for units of measure
    /// In fact, it is a bit too simple, since some measures (like cups or spoons) 
    /// may correspond to slightly different number of grams for different foods
    /// Currently, these discrepancies are ignored on purpose
    /// If you want to change this, you need to know the physical density of each food
    /// 
    /// </summary>
    public class Measure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsKnownUniversally { get; set; }

        [Required]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float Grams { get; set; }

        public ICollection<DietItem> DietItems { get; set; }
        public ICollection<FoodMeasure> FoodItems { get; set; }
        public Measure()
        {
            IsKnownUniversally = true;
            DietItems = new Collection<DietItem>();
            FoodItems = new Collection<FoodMeasure>();
        }

    }
}
