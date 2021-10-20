using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    public static class DataHelper
    {
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
