using System.Collections.Generic;

namespace DietAnalyzer.Data
{
    /// <summary>
    /// 
    /// A static class containing data constants  
    /// HighValues - maximum allowed intake for each nutrient, 
    /// expressed as a number where 100 = recommended daily intake. 
    /// Note that there is no LowValues dictionary, since by definition every LowValue equals 100 in this notation. 
    /// Note also that some nutrients are considered to be safe ever in very large doses, 
    /// represented by float.MaxValue.
    /// 
    /// </summary>
    public static class DataHelper
    {
        public const float CarbProtToFatCalorieRatio = 2.25F;

        public static Dictionary<string, float> HighValues = new Dictionary<string, float>
        {
            { "VitaminA", 330.0F },
            { "VitaminB1", float.MaxValue },
            { "VitaminB2", float.MaxValue },
            { "VitaminB3", 220.0F },
            { "VitaminB6", 5880.0F },
            { "VitaminB9", 250.0F },
            { "VitaminB12", float.MaxValue },
            { "VitaminC", 2220.0F },
            { "VitaminD", 660.0F },
            { "VitaminE", 6660.0F },
            { "VitaminK", float.MaxValue },

            { "Calcium", 250.0F },
            { "Iron", 250.0F },
            { "Magnesium", float.MaxValue },
            { "Phosphorus", 570.0F },
            { "Potassium", float.MaxValue },
            { "Sodium", 150.0F },
            { "Zinc", 360.0F },
            { "Copper", 1110.0F },
            { "Manganese", 470.0F },
            { "Selenium", 720.0F },
        };

    }
}
