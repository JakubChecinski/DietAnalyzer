using DietAnalyzer.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Data
{
    public static partial class MeasureSeeder
    {
		private static FoodMeasure[] ConstructFoodMeasures()
		{
			return new FoodMeasure[]
			{
				new FoodMeasure
				{
					Id = 1,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 1,
				},
				new FoodMeasure
				{
					Id = 2,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 2,
				},
				new FoodMeasure
				{
					Id = 3,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 3,
				},
				new FoodMeasure
				{
					Id = 4,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 4,
				},
				new FoodMeasure
				{
					Id = 5,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 5,
				},
				new FoodMeasure
				{
					Id = 6,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 6,
				},
				new FoodMeasure
				{
					Id = 7,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 7,
				},
				new FoodMeasure
				{
					Id = 8,
					IsCurrentlyLinked = true,
					MeasureId = 1,
					FoodItemId = 8,
				},
				new FoodMeasure
				{
					Id = 10,
					IsCurrentlyLinked = true,
					MeasureId = 2,
					FoodItemId = 2,
				},
				new FoodMeasure
				{
					Id = 19,
					IsCurrentlyLinked = true,
					MeasureId = 3,
					FoodItemId = 3,
				},
				new FoodMeasure
				{
					Id = 31,
					IsCurrentlyLinked = true,
					MeasureId = 4,
					FoodItemId = 7,
				}
			};
		}
	}
}
