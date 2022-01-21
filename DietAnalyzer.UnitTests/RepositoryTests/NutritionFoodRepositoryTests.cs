using DietAnalyzer.Data;
using DietAnalyzer.Data.Repositories;
using DietAnalyzer.Models.Domains;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace DietAnalyzer.UnitTests.RepositoryTests
{
    class NutritionFoodRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private NutritionFoodRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // why? because initialization code interferes and inserts its own nutritions
            context.NutritionFoods.RemoveRange(context.NutritionFoods);
            context.SaveChanges();
            // back to normal flow
            context.NutritionFoods.AddRange(
                new NutritionFood { Id = 1 }
            );
            context.SaveChanges();
        }

        [Test]
        public void Add_NutritionSupplied_AddNutritionToDb()
        {
            Init();
            var newNutritionId = 2;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new NutritionFoodRepository(context);

            repository.Add(new NutritionFood { Id = newNutritionId });
            context.SaveChanges();

            var outputCollection = context.NutritionFoods.Where(x => x.Id == newNutritionId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_NutritionFound_ChangeCalories()
        {
            Init();
            var newCalories = 123;
            var stubNutrition = new NutritionFood() { Id = 1, CaloriesPer100g = newCalories };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new NutritionFoodRepository(context);

            repository.Update(stubNutrition);
            context.SaveChanges();

            var outputCollection = context.NutritionFoods.Where(x => x.CaloriesPer100g == newCalories);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_NutritionNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubNutrition = new NutritionFood() { Id = -1 };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new NutritionFoodRepository(context);

            Action action = () => repository.Update(stubNutrition);
            action.Should().Throw<InvalidOperationException>();
        }

    }
}
