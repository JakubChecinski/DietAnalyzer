using DietAnalyzer.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{

	/// See DataSeeder.cs for more comments on data seeding classes

	public static partial class MeasureSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measure>().HasData(ConstructMeasures());
            modelBuilder.Entity<FoodMeasure>().HasData(ConstructFoodMeasures());
        }

        private static Measure[] ConstructMeasures()
        {
            return new Measure[]
            {
				new Measure
				{
					Id = 1,
					Name = "grams",
					Grams = 1,
					IsKnownUniversally = true,
				},
				new Measure
				{
					Id = 2,
					Name = "tablespoons",
					Grams = 15,
					IsKnownUniversally = true,
				},
				new Measure
				{
					Id = 3,
					Name = "teaspoons",
					Grams = 5,
					IsKnownUniversally = true,
				},
				new Measure
				{
					Id = 4,
					Name = "cups",
					Grams = 250,
					IsKnownUniversally = true,
				},
				new Measure
				{
					Id = 10,
					Name = "large bananas",
					Grams = 135,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 11,
					Name = "large eggs",
					Grams = 50,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 12,
					Name = "slices",
					Grams = 35,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 13,
					Name = "medium sardines",
					Grams = 12,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 14,
					Name = "medium tomatoes",
					Grams = 170,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 15,
					Name = "medium onions",
					Grams = 110,
					IsKnownUniversally = false,
				},
				
			};
        }

    }
}
