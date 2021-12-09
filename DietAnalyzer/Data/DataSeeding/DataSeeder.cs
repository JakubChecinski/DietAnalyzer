using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    /// <summary>
    /// 
    /// This is the main class for DataSeeding
    /// It uses Entity to populate database with pre-defined objects (foods, measures, etc.)
    /// Mostly for the sake of convenience and easier demonstration of how the app works
    /// If you don't want it, comment out the respective line in ApplicationDbContext
    /// 
    /// To edit the predefined values of:
    ///     Food names and images - go to FoodSeeder.cs
    ///     Food nutritional values - go to FoodNutritionSeeder.cs
    ///     Food suitabilities for different diets - go to FoodRestrictionSeeder.cs
    ///     Measure names and grams - go to MeasureSeeder.cs
    ///     Which measures are used for each food - go to MeasureFoodLinkSeeder.cs
    /// 
    /// </summary>
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
			FoodSeeder.Seed(modelBuilder);
            MeasureSeeder.Seed(modelBuilder);
		}
    }
}
