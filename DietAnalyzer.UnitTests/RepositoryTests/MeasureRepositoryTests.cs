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
    class MeasureRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private MeasureRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // why? because initialization code interferes and inserts its own measures
            context.Measures.RemoveRange(context.Measures);
            context.SaveChanges();
            // back to normal flow
            context.Measures.AddRange(
                new Measure { Id = 1, UserId = "abc" },
                new Measure { Id = 2, UserId = "abc" },
                new Measure { Id = 3, UserId = "def" },
                new Measure { Id = 4, UserId = null }
            );
            context.SaveChanges();
        }

        [TestCase("abc", 3)]
        [TestCase("def", 2)]
        [TestCase("wrongId", 1)]
        public void Get_UserIdSupplied_ReturnMeasureWithThisIdOrNull(string userId, int expectedCollectionSize)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            var result = repository.Get(userId);

            result.Should().HaveCount(expectedCollectionSize);
        }

        [TestCase("abc", 2)]
        [TestCase("def", 1)]
        [TestCase("wrongId", 0)]
        public void GetCustom_UserIdSupplied_ReturnMeasureWithThisId(string userId, int expectedCollectionSize)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            var result = repository.GetCustom(userId);

            result.Should().HaveCount(expectedCollectionSize);
        }

        [Test]
        public void Get_MeasureFound_ReturnMeasure()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            var result = repository.Get(1);

            result.Id.Should().Be(1);
            result.UserId.Should().Be("abc");
        }

        [Test]
        public void Get_MeasureIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            Action action = () => repository.Get(-1);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Add_MeasureSupplied_AddMeasureToDb()
        {
            Init();
            var newMeasureId = 5;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            repository.Add(new Measure { Id = newMeasureId });
            context.SaveChanges();

            var outputCollection = context.Measures.Where(x => x.Id == newMeasureId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_MeasureFound_ChangeMeasureNameAndGrams()
        {
            Init();
            var newName = "testName";
            var newGrams = 5;
            var stubMeasure = new Measure() { Id = 1, UserId = "abc", Name = newName, Grams = newGrams };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            repository.Update(stubMeasure, stubMeasure.UserId);
            context.SaveChanges();

            var outputCollection = context.Measures.Where(x => x.Name == newName);
            outputCollection.Should().HaveCount(1);
            outputCollection.First().Grams.Should().Be(newGrams);
        }

        [Test]
        public void Update_MeasureOrUserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubMeasure = new Measure() { Id = 1, UserId = "wrongId" };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            Action action = () => repository.Update(stubMeasure, stubMeasure.UserId);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Delete_MeasureFound_RemoveMeasureFromDb()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            repository.Delete(1, "abc");
            context.SaveChanges();

            var outputCollection = context.Measures.Where(x => x.Id == 1);
            outputCollection.Should().HaveCount(0);
        }

        [Test]
        public void Delete_MeasureOrUserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new MeasureRepository(context);

            Action action = () => repository.Delete(-1, "abc");
            Action action2 = () => repository.Delete(1, "wrongId");
            action.Should().Throw<InvalidOperationException>();
            action2.Should().Throw<InvalidOperationException>();
        }

    }
}
