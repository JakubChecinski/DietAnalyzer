using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// A domain class representing a single diet
    /// 
    /// </summary>
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
        public NutritionDiet Nutritions { get; set; }
        public ICollection<EvaluationResult> Summary { get; set; }
        public Diet()
        {
            DietItems = new Collection<DietItem>();
            Summary = new Collection<EvaluationResult>();
        }
    }
}
