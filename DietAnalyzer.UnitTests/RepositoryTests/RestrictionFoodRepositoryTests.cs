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
    class RestrictionFoodRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private RestrictionFoodRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // why? because initialization code interferes and inserts its own restrictions
            context.RestrictionsFoods.RemoveRange(context.RestrictionsFoods);
            context.SaveChanges();
            // back to normal flow
            context.RestrictionsFoods.AddRange(
                new RestrictionFood { Id = 1, Pescetarian = false }
            );
            context.SaveChanges();
        }

        [Test]
        public void Add_RestrictionSupplied_AddRestrictionToDb()
        {
            Init();
            var newRestrictionId = 2;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionFoodRepository(context);

            repository.Add(new RestrictionFood { Id = newRestrictionId });
            context.SaveChanges();

            var outputCollection = context.FoodItems.Where(x => x.Id == newRestrictionId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_RestrictionFound_SwitchPescetarianValue()
        {
            Init();
            var stubRestriction = new RestrictionFood() { Id = 1, Pescetarian = true };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionFoodRepository(context);

            repository.Update(stubRestriction);
            context.SaveChanges();

            var outputCollection = context.RestrictionsFoods.Where(x => x.Id == 1);
            outputCollection.First().Pescetarian.Should().BeTrue();
        }

        [Test]
        public void Update_RestrictionNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubRestriction = new RestrictionFood() { Id = -1 };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new RestrictionFoodRepository(context);

            Action action = () => repository.Update(stubRestriction);
            action.Should().Throw<InvalidOperationException>();
        }

    }
}
