using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DietAnalyzer.Models.DataAttributes;


namespace DietAnalyzer.Models.Domains
{
    public class NutritionInfo
    {
        [Key]
        public int Id { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }


        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? CaloriesPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? FiberPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SugarPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        [GTENumericalSum("FiberPer100g", "SugarPer100g", 
            ErrorMessage = "Carbohydrates value cannot be smaller than the sum of fibers and sugars")]
        public float? CarbohydratesPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SaturatedFatPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        [GTENumericalSum("SaturatedFatPer100g",
            ErrorMessage = "Fats value cannot be smaller than the saturated fats value")]
        public float? FatsPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? ProteinsPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminAPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminCPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminDPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminEPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminKPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB1Per100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB2Per100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB3Per100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB6Per100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB9Per100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB12Per100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? CalciumPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? IronPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? MagnesiumPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? PhosphorusPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? PotassiumPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SodiumPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? ZincPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? CopperPer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? ManganesePer100g { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SeleniumPer100g { get; set; }

    }
}
