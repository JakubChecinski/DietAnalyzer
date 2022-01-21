using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    /// <remarks>
    /// 
    /// This is the main class for DataSeeding
    /// It uses Entity to populate database with pre-defined objects (foods, measures, etc.)
    /// If you don't want it, comment out the respective line in ApplicationDbContext (and maybe Register form, see below)
    /// 
    /// To edit the predefined values of:
    ///     Food names and images - go to FoodSeeder.cs
    ///     Food nutritional values - go to FoodNutritionSeeder.cs
    ///     Food suitabilities for different diets - go to FoodRestrictionSeeder.cs
    ///     Measure names and grams - go to MeasureSeeder.cs
    ///     Which measures are used for each food - go to MeasureFoodLinkSeeder.cs
    ///     
    /// 
    /// To see example USER data (what users could insert themselves), see Services -> Utilities -> ExampleDataService
    /// What is the difference? 
    /// 
    /// DataSeeder seeds "hard" data, i.e., objects not connected to any particular user
    /// These objects are always visible for any application user - in a sense, they are a part of the app itself
    /// 
    /// ExampleDataService seeds "soft" data, i.e., objects tied to a specific (example) user. Essentially, 
    /// it is a simulation of a new user clicking around the app and inserting custom values in different tabs
    /// But here we do it automatically for the sake of convenience and easier demonstration of how the app works
    /// If you don't want it, comment out the respective line in the Register form
    /// 
    /// Note: ExampleDataService depends on DataSeeder results, but not the other way around
    /// So you can have both seeds or neither seed or only the hard seed, but you cannot have only the soft seed
    /// 
    /// </remarks>
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
			FoodSeeder.Seed(modelBuilder);
            MeasureSeeder.Seed(modelBuilder);
		}
    }
}
