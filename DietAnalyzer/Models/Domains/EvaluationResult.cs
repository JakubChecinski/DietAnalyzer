using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// A domain class representing the evaluation result for a single nutrient,
    /// i.e., one row in the table of recommendations that the user can receive for each of their diets. 
    /// To see how it works, visit IEvaluationService and class(es) implementing it. 
    /// 
    /// </summary>
    public class EvaluationResult
    {
        [Key]
        public int Id { get; set; }

        public int DietId { get; set; }
        public Diet Diet { get; set; }

        public string NutrientName { get; set; }

        [EnumDataType(typeof(Level))]
        public Level Level { get; set; }

        public float? Value { get; set; }
        public string Unit { get; set; }
        public string Suggestions { get; set; }

    }

    public enum Level
    {
        Low = 0,
        Normal = 1,
        High = 2,
        Unrated = 5,
    }

}
