using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class NutritionDiet : NutritionInfo
    {
        [Key]
        public int Id { get; set; }

        public int DietId { get; set; }
        public Diet Diet { get; set; }

    }
}
