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
    class RestrictionUserRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private RestrictionUserRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.RestrictionsUsers.AddRange(
                new RestrictionUser { Id = 1, UserId = "abc" },
                new RestrictionUser { Id = 2, UserId = "def" }
            );
            context.SaveChanges();
        }

        [TestCase("abc", 1)]
        [TestCase("def", 2)]
        public void Get_CorrectUserId_ReturnRestrictionWithCorrectId(string userId, int expectedId)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionUserRepository(context);

            var result = repository.Get(userId);

            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Get_IncorrectUserId_ReturnNull()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionUserRepository(context);

            var result = repository.Get("wrongId");

            result.Should().BeNull();
        }

        [Test]
        public void Add_RestrictionSupplied_AddRestrictionToDb()
        {
            Init();
            var newRestrictionId = 3;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionUserRepository(context);

            repository.Add(new RestrictionUser { Id = newRestrictionId });
            context.SaveChanges();

            var outputCollection = context.FoodItems.Where(x => x.Id == newRestrictionId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_RestrictionFound_SwitchPescetarianValue()
        {
            Init();
            var stubRestriction = new RestrictionUser() { Id = 1, Pescetarian = true };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionUserRepository(context);

            repository.Update(stubRestriction);
            context.SaveChanges();

            var outputCollection = context.RestrictionsUsers.Where(x => x.Id == 1);
            outputCollection.First().Pescetarian.Should().BeTrue();
        }

        [Test]
        public void Update_RestrictionNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubRestriction = new RestrictionUser() { Id = -1 };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionUserRepository(context);

            Action action = () => repository.Update(stubRestriction);
            action.Should().Throw<InvalidOperationException>();
        }

    }
}
