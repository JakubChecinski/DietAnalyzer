using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    public class EvaluationResult
    {
        [Key]
        public int Id { get; set; }

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
