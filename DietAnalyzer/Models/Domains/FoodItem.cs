using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public NutritionInfo Nutrition { get; set; }

        public RestrictionsInfo Restrictions { get; set; }

        public ICollection<FoodDietRecommendation> Recommendations { get; set; }
        public ICollection<FoodMeasure> Measures { get; set; }
        public ICollection<DietItem> DietItems { get; set; }
        public FoodItem()
        {
            Recommendations = new Collection<FoodDietRecommendation>();
            DietItems = new Collection<DietItem>();
            Measures = new Collection<FoodMeasure>();
        }

    }
}
