using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.Domains
{
    public class NutritionDiet : Nutrition
    {
        [Key]
        public int Id { get; set; }

        public int DietId { get; set; }
        public Diet Diet { get; set; }

    }
}
