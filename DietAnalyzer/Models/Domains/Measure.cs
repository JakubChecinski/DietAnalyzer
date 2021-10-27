using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
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

        public bool IsPubliclyKnown { get; set; }

        [Required]
        public float Grams { get; set; }

        public ICollection<DietItem> DietItems { get; set; }
        public ICollection<FoodMeasure> FoodItems { get; set; }
        public Measure()
        {
            IsPubliclyKnown = true;
            DietItems = new Collection<DietItem>();
            FoodItems = new Collection<FoodMeasure>();
        }

    }
}
