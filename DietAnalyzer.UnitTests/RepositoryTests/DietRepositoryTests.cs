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
    class DietRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private DietRepository repository;
        private Diet exampleDiet;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            exampleDiet = new Diet { Id = 1, UserId = "abc" };
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Diets.AddRange(
                exampleDiet,
                new Diet { Id = 2, UserId = "abc" },
                new Diet { Id = 3, UserId = "def" }
            );
            context.SaveChanges();
        }

        [TestCase("abc", 2)]
        [TestCase("def", 1)]
        [TestCase("wrongId", 0)]
        public void Get_UserIdSupplied_ReturnAllDiets(string userId, int expectedCollectionSize)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            var result = repository.Get(userId);

            result.Should().HaveCount(expectedCollectionSize);
        }

        [Test]
        public void Get_DietIdFound_ReturnDiet()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            var result = repository.Get("abc", 1);

            result.Id.Should().Be(1);
        }

        [Test]
        public void Get_DietIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.Get("abc", -1);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Get_UserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.Get("wrongId", 1);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void GetWithDietItemChildren_DietIdFound_ReturnDiet()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            var result = repository.GetWithDietItemChildren("abc", 1);

            result.Id.Should().Be(1);
        }

        [Test]
        public void GetWithDietItemChildren_DietIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.GetWithDietItemChildren("abc", -1);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void GetWithDietItemChildren_UserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.GetWithDietItemChildren("wrongId", 1);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Add_DietSupplied_AddDietToDb()
        {
            Init();
            var newDietId = 4;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            repository.Add(new Diet { Id = newDietId });
            context.SaveChanges();

            var outputCollection = context.Diets.Where(x => x.Id == newDietId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_DietFound_ChangeDietName()
        {
            Init();
            var newName = "testName";
            var stubDiet = new Diet() { Id = exampleDiet.Id, UserId = exampleDiet.UserId, Name = newName };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            repository.Update(stubDiet, stubDiet.UserId);
            context.SaveChanges();

            var outputCollection = context.Diets.Where(x => x.Name == newName);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_DietIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubDiet = new Diet() { Id = exampleDiet.Id, UserId = "wrongId" };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.Update(stubDiet, stubDiet.UserId);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Delete_DietFound_RemoveDietFromDb()
        {
            Init();
            var idToDelete = 1;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            repository.Delete(idToDelete, "abc");
            context.SaveChanges();

            var outputCollection = context.DietItems.Where(x => x.Id == idToDelete);
            outputCollection.Should().HaveCount(0);
        }

        [Test]
        public void Delete_DietIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.Delete(-1, "abc");
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Delete_UserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietRepository(context);

            Action action = () => repository.Delete(1, "wrongId");
            action.Should().Throw<InvalidOperationException>();
        }


    }
}
