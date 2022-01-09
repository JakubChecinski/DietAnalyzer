using DietAnalyzer.Data;
using DietAnalyzer.Data.Repositories;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.UnitTests.Extensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietAnalyzer.UnitTests.RepositoryTests
{
    class FoodMeasureRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private FoodMeasureRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // why? because initialization code interferes and inserts its own foodMeasures
            context.FoodMeasures.RemoveRange(context.FoodMeasures);
            context.SaveChanges();
            // back to normal flow
            context.FoodMeasures.AddRange(
                new FoodMeasure { Id = 1, FoodItemId = 1, MeasureId = 1, IsCurrentlyLinked = false }
            );
            context.SaveChanges();
        }

        [Test]
        public void Add_FoodAndMeasureIdsSupplied_AddFoodMeasureToDb()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodMeasureRepository(context);

            repository.Add(2, 2);
            context.SaveChanges();

            var outputCollection = context.FoodMeasures.Where(x => x.FoodItemId == 2);
            outputCollection.Should().HaveCount(1);
            outputCollection = context.FoodMeasures.Where(x => x.MeasureId == 2);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Add_FoodMeasureAlreadyExists_ThrowException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodMeasureRepository(context);

            Action action = () => repository.Add(1, 1);
            action.Should().Throw<Exception>();
        }


        [Test]
        public void Update_FoodMeasureFound_ChangeIsCurrentlyLinked()
        {
            Init();
            var stubFoodMeasure = new FoodMeasure() { Id = 1, 
                FoodItemId = 1, MeasureId = 1, IsCurrentlyLinked = true };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodMeasureRepository(context);

            repository.Update(stubFoodMeasure);
            context.SaveChanges();

            var output = context.FoodMeasures.Single(x => x.Id == 1);
            output.IsCurrentlyLinked.Should().BeTrue();
        }

        [Test]
        public void Update_FoodMeasureIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubFoodMeasure = new FoodMeasure() { Id = -1 };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodMeasureRepository(context);

            Action action = () => repository.Update(stubFoodMeasure);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Delete_FoodMeasureFound_RemoveFoodMeasureFromDb()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodMeasureRepository(context);

            repository.Delete(1);
            context.SaveChanges();

            var outputCollection = context.FoodMeasures.Where(x => x.Id == 1);
            outputCollection.Should().HaveCount(0);
        }

        [Test]
        public void Delete_FoodMeasureIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodMeasureRepository(context);

            Action action = () => repository.Delete(-1);
            action.Should().Throw<InvalidOperationException>();
        }

    }
}
