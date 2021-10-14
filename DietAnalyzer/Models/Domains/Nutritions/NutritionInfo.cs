using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DietAnalyzer.Models.DataAttributes;


namespace DietAnalyzer.Models.Domains
{
    public abstract class NutritionInfo
    { 
        [Display(Name = "Calories:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? CaloriesPer100g { get; set; }

        [Display(Name = "Fiber:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? FiberPer100g { get; set; }

        [Display(Name = "Sugar:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SugarPer100g { get; set; }

        [Display(Name = "Carbohydrates:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        [GTENumericalSum("FiberPer100g", "SugarPer100g", 
            ErrorMessage = "Carbohydrates value cannot be smaller than the sum of fibers and sugars")]
        public float? CarbohydratesPer100g { get; set; }

        [Display(Name = "Saturated fats:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SaturatedFatPer100g { get; set; }

        [Display(Name = "Fats:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        [GTENumericalSum("SaturatedFatPer100g",
            ErrorMessage = "Fats value cannot be smaller than the saturated fats value")]
        public float? FatsPer100g { get; set; }

        [Display(Name = "Proteins:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? ProteinsPer100g { get; set; }

        [Display(Name = "Vitamin A:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminAPer100g { get; set; }

        [Display(Name = "Vitamin C:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminCPer100g { get; set; }

        [Display(Name = "Vitamin D:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminDPer100g { get; set; }

        [Display(Name = "Vitamin E:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminEPer100g { get; set; }

        [Display(Name = "Vitamin K:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminKPer100g { get; set; }

        [Display(Name = "Vitamin B1:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB1Per100g { get; set; }

        [Display(Name = "Vitamin B2:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB2Per100g { get; set; }

        [Display(Name = "Vitamin B3:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB3Per100g { get; set; }

        [Display(Name = "Vitamin B6:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB6Per100g { get; set; }

        [Display(Name = "Vitamin B9:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB9Per100g { get; set; }

        [Display(Name = "Vitamin B12:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? VitaminB12Per100g { get; set; }

        [Display(Name = "Calcium:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? CalciumPer100g { get; set; }

        [Display(Name = "Iron:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? IronPer100g { get; set; }

        [Display(Name = "Magnesium:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? MagnesiumPer100g { get; set; }

        [Display(Name = "Phosphorus:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? PhosphorusPer100g { get; set; }

        [Display(Name = "Potassium:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? PotassiumPer100g { get; set; }

        [Display(Name = "Sodium:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SodiumPer100g { get; set; }

        [Display(Name = "Zinc:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? ZincPer100g { get; set; }

        [Display(Name = "Copper:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? CopperPer100g { get; set; }

        [Display(Name = "Manganese:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? ManganesePer100g { get; set; }

        [Display(Name = "Selenium:")]
        [Range(0.0, float.MaxValue, ErrorMessage = "The value must be positive")]
        public float? SeleniumPer100g { get; set; }

    }
}
