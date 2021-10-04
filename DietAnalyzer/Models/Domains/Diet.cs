using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class Diet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<DietItem> DietItems { get; set; }
        public ICollection<FoodDietRecommendation> Recommendations { get; set; }
        public NutritionInfo Nutritions { get; set; }
        public Diet()
        {
            DietItems = new Collection<DietItem>();
            Recommendations = new Collection<FoodDietRecommendation>();
        }
    }
}
