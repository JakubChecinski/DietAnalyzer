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
    class DietItemRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private DietItemRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            //dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(local)\\SQLEXPRESS;Database=DietAnalyzerTests;User Id=JCH;Password=pwd").Options;
            //dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Filename=Test.db").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.DietItems.AddRange(
                new DietItem { Id = 1, DietId = 10 },
                new DietItem { Id = 2, DietId = 10 },
                new DietItem { Id = 3, DietId = 20 }
            );
            context.SaveChanges();
        }

        [TestCase(10, 2)]
        [TestCase(20, 1)]
        [TestCase(-1, 0)]
        public void Get_IdSupplied_ReturnCollectionOfMatchingItems(int dietId, int expectedCollectionSize)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietItemRepository(context);

            var result = repository.Get(dietId);

            result.Should().HaveCount(expectedCollectionSize);
        }

        [Test]
        public void Add_DietItemSupplied_AddDietItemToDb()
        {
            Init();
            var newDietId = 30;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietItemRepository(context);

            repository.Add(new DietItem { DietId = newDietId });
            context.SaveChanges();

            var outputCollection = context.DietItems.Where(x => x.DietId == newDietId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Delete_DietItemFound_RemoveDietItemFromDb()
        {
            Init();
            var idToDelete = 10;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietItemRepository(context);

            repository.Delete(new DietItem { Id = 1, DietId = idToDelete });
            context.SaveChanges();

            var outputCollection = context.DietItems.Where(x => x.DietId == idToDelete);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Delete_DietItemNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new DietItemRepository(context);

            Action action = () => repository.Delete(new DietItem { Id = -1 });
            action.Should().Throw<InvalidOperationException>();
        }

    }
}
