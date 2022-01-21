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
    class NutritionDietRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private NutritionDietRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // why? because initialization code interferes and inserts its own nutritions
            context.NutritionDiets.RemoveRange(context.NutritionDiets);
            context.SaveChanges();
            // back to normal flow
            context.NutritionDiets.AddRange(
                new NutritionDiet { Id = 1 }
            );
            context.SaveChanges();
        }

        [Test]
        public void Add_NutritionSupplied_AddNutritionToDb()
        {
            Init();
            var newNutritionId = 2;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new NutritionDietRepository(context);

            repository.Add(new NutritionDiet { Id = newNutritionId });
            context.SaveChanges();

            var outputCollection = context.NutritionDiets.Where(x => x.Id == newNutritionId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_NutritionFound_ChangeCalories()
        {
            Init();
            var newCalories = 123;
            var stubNutrition = new NutritionDiet() { Id = 1, CaloriesPer100g = newCalories };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new NutritionDietRepository(context);

            repository.Update(stubNutrition);
            context.SaveChanges();

            var outputCollection = context.NutritionDiets.Where(x => x.CaloriesPer100g == newCalories);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_NutritionNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubNutrition = new NutritionDiet() { Id = -1 };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new NutritionDietRepository(context);

            Action action = () => repository.Update(stubNutrition);
            action.Should().Throw<InvalidOperationException>();
        }

    }
}
