using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DietAnalyzer.Models.DataAttributes;


namespace DietAnalyzer.Models.Domains
{
    public abstract class Nutrition
    { 
        [Display(Name = "Calories:")]
        public float? CaloriesPer100g { get; set; }

        [Display(Name = "Fiber:")]
        public float? FiberPer100g { get; set; }

        [Display(Name = "Sugar:")]
        public float? SugarPer100g { get; set; }

        [Display(Name = "Carbohydrates:")]
        [GTENumericalSum("FiberPer100g", "SugarPer100g", 
            ErrorMessage = "Carbohydrates value cannot be smaller than the sum of fibers and sugars")]
        public float? CarbohydratesPer100g { get; set; }

        [Display(Name = "Saturated fats:")]
        public float? SaturatedFatPer100g { get; set; }

        [Display(Name = "Fats:")]
        [GTENumericalSum("SaturatedFatPer100g",
            ErrorMessage = "Fats value cannot be smaller than the saturated fats value")]
        public float? FatsPer100g { get; set; }

        [Display(Name = "Proteins:")]
        public float? ProteinsPer100g { get; set; }

        [Display(Name = "Vitamin A:")]
        public float? VitaminAPer100g { get; set; }

        [Display(Name = "Vitamin C:")]
        public float? VitaminCPer100g { get; set; }

        [Display(Name = "Vitamin D:")]
        public float? VitaminDPer100g { get; set; }

        [Display(Name = "Vitamin E:")]
        public float? VitaminEPer100g { get; set; }

        [Display(Name = "Vitamin K:")]
        public float? VitaminKPer100g { get; set; }

        [Display(Name = "Vitamin B1:")]
        public float? VitaminB1Per100g { get; set; }

        [Display(Name = "Vitamin B2:")]
        public float? VitaminB2Per100g { get; set; }

        [Display(Name = "Vitamin B3:")]
        public float? VitaminB3Per100g { get; set; }

        [Display(Name = "Vitamin B6:")]
        public float? VitaminB6Per100g { get; set; }

        [Display(Name = "Vitamin B9:")]
        public float? VitaminB9Per100g { get; set; }

        [Display(Name = "Vitamin B12:")]
        public float? VitaminB12Per100g { get; set; }

        [Display(Name = "Calcium:")]
        public float? CalciumPer100g { get; set; }

        [Display(Name = "Iron:")]
        public float? IronPer100g { get; set; }

        [Display(Name = "Magnesium:")]
        public float? MagnesiumPer100g { get; set; }

        [Display(Name = "Phosphorus:")]
        public float? PhosphorusPer100g { get; set; }

        [Display(Name = "Potassium:")]
        public float? PotassiumPer100g { get; set; }

        [Display(Name = "Sodium:")]
        public float? SodiumPer100g { get; set; }

        [Display(Name = "Zinc:")]
        public float? ZincPer100g { get; set; }

        [Display(Name = "Copper:")]
        public float? CopperPer100g { get; set; }

        [Display(Name = "Manganese:")]
        public float? ManganesePer100g { get; set; }

        [Display(Name = "Selenium:")]
        public float? SeleniumPer100g { get; set; }

    }
}
