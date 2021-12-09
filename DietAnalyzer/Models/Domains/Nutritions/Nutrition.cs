using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DietAnalyzer.Models.DataAttributes;


namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// A domain class representing a table of nutritional values
    /// Such a table can belong to either a single food or an entire diet
    /// Which is why this class is abstract and we have two concrete versions inheriting after it
    /// 
    /// </summary>

    public abstract class Nutrition
    { 
        [Display(Name = "Calories:")]
        // note: calories can be negative (not an omission)
        public float? CaloriesPer100g { get; set; }

        [Display(Name = "Fiber:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? FiberPer100g { get; set; }

        [Display(Name = "Sugar:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? SugarPer100g { get; set; }

        [Display(Name = "Carbohydrates:")]
        [GTENumericalSum("FiberPer100g", "SugarPer100g", 
            ErrorMessage = "Carbohydrates value cannot be smaller than the sum of fibers and sugars")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? CarbohydratesPer100g { get; set; }

        [Display(Name = "Saturated fats:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? SaturatedFatPer100g { get; set; }

        [Display(Name = "Fats:")]
        [GTENumericalSum("SaturatedFatPer100g",
            ErrorMessage = "Fats value cannot be smaller than the saturated fats value")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? FatsPer100g { get; set; }

        [Display(Name = "Proteins:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? ProteinsPer100g { get; set; }

        [Display(Name = "Vitamin A:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminAPer100g { get; set; }

        [Display(Name = "Vitamin C:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminCPer100g { get; set; }

        [Display(Name = "Vitamin D:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminDPer100g { get; set; }

        [Display(Name = "Vitamin E:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminEPer100g { get; set; }

        [Display(Name = "Vitamin K:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminKPer100g { get; set; }

        [Display(Name = "Vitamin B1:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminB1Per100g { get; set; }

        [Display(Name = "Vitamin B2:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminB2Per100g { get; set; }

        [Display(Name = "Vitamin B3:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminB3Per100g { get; set; }

        [Display(Name = "Vitamin B6:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminB6Per100g { get; set; }

        [Display(Name = "Vitamin B9:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminB9Per100g { get; set; }

        [Display(Name = "Vitamin B12:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? VitaminB12Per100g { get; set; }

        [Display(Name = "Calcium:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? CalciumPer100g { get; set; }

        [Display(Name = "Iron:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? IronPer100g { get; set; }

        [Display(Name = "Magnesium:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? MagnesiumPer100g { get; set; }

        [Display(Name = "Phosphorus:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? PhosphorusPer100g { get; set; }

        [Display(Name = "Potassium:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? PotassiumPer100g { get; set; }

        [Display(Name = "Sodium:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? SodiumPer100g { get; set; }

        [Display(Name = "Zinc:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? ZincPer100g { get; set; }

        [Display(Name = "Copper:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? CopperPer100g { get; set; }

        [Display(Name = "Manganese:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? ManganesePer100g { get; set; }

        [Display(Name = "Selenium:")]
        [LocaleSafeRange(0.0, float.MaxValue, ErrorMessage = "This value must be positive.")]
        public float? SeleniumPer100g { get; set; }

    }
}
