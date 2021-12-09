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
					Name = "large bananas",
					Grams = 135,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 3,
					Name = "large eggs",
					Grams = 50,
					IsKnownUniversally = false,
				},
				new Measure
				{
					Id = 4,
					Name = "slices",
					Grams = 35,
					IsKnownUniversally = false,
				}
			};
        }

    }
}
