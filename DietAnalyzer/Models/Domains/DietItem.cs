using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class DietItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
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
