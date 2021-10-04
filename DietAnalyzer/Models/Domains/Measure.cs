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

        [Required]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float Grams { get; set; }

        public ICollection<DietItem> DietItems { get; set; }
        public Measure()
        {
            DietItems = new Collection<DietItem>();
        }

    }
}
