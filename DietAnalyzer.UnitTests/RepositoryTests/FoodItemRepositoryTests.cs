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
    class FoodItemRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        private FoodItemRepository repository;

        private void Init()
        {
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase").Options;
            using var context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // why? because initialization code interferes and inserts its own foods
            context.FoodItems.RemoveRange(context.FoodItems);
            context.RestrictionsFoods.RemoveRange(context.RestrictionsFoods);
            context.SaveChanges();
            // back to normal flow
            context.FoodItems.AddRange(
                new FoodItem
                {
                    Id = 1,
                    UserId = "abc",
                    Restrictions = new RestrictionFood { FoodItemId = 1 }
                },
                new FoodItem
                {
                    Id = 2,
                    UserId = "abc",
                    Restrictions = new RestrictionFood { FoodItemId = 2, Diabetes = false }
                },
                new FoodItem
                {
                    Id = 3,
                    UserId = "def",
                    Restrictions = new RestrictionFood { FoodItemId = 3 }
                },
                new FoodItem
                {
                    Id = 4,
                    UserId = null,
                    Restrictions = new RestrictionFood { FoodItemId = 4 }
                }
            );
            context.SaveChanges();
        }

        [TestCase("abc", 3)]
        [TestCase("def", 2)]
        [TestCase("wrongId", 1)]
        public void Get_UserIdSupplied_ReturnFoodWithThisIdOrWithNull(string userId, int expectedCollectionSize)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            var result = repository.Get(userId);

            result.Should().HaveCount(expectedCollectionSize);
        }

        [Test]
        public void Get_UserRestrictionsSupplied_ReturnOnlySuitableFoods()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);
            var testRestrictions = new RestrictionUser { Diabetes = true };

            var result = repository.Get("abc", testRestrictions);

            result.Should().HaveCount(2);
        }

        [TestCase("abc", 2)]
        [TestCase("def", 1)]
        [TestCase("wrongId", 0)]
        public void GetCustom_UserIdSupplied_ReturnFoodWithThisId(string userId, int expectedCollectionSize)
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            var result = repository.GetCustom(userId);

            result.Should().HaveCount(expectedCollectionSize);
        }

        [Test]
        public void GetCustom_UserRestrictionsSupplied_ReturnOnlySuitableFoods()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);
            var testRestrictions = new RestrictionUser { Diabetes = true };

            var result = repository.GetCustom("abc", testRestrictions);

            result.Should().HaveCount(1);
        }

        [Test]
        public void Get_FoodFound_ReturnFood()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            var result = repository.Get("abc", 1);

            result.Id.Should().Be(1);
            result.UserId.Should().Be("abc");
        }

        [Test]
        public void Get_FoodOrUserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            Action action = () => repository.Get("abc", -1);
            Action action2 = () => repository.Get("wrongId", 1);

            action.Should().Throw<InvalidOperationException>();
            action2.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Add_FoodSupplied_AddFoodToDb()
        {
            Init();
            var newFoodId = 5;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            repository.Add(new FoodItem { Id = newFoodId });
            context.SaveChanges();

            var outputCollection = context.FoodItems.Where(x => x.Id == newFoodId);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_FoodFound_ChangeFoodName()
        {
            Init();
            var newName = "testName";
            var stubFood = new FoodItem() { Id = 1, UserId = "abc", Name = newName };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            repository.Update(stubFood, stubFood.UserId);
            context.SaveChanges();

            var outputCollection = context.FoodItems.Where(x => x.Name == newName);
            outputCollection.Should().HaveCount(1);
        }

        [Test]
        public void Update_FoodNotFound_ThrowInvalidOperationException()
        {
            Init();
            var stubFood = new FoodItem() { Id = 1, UserId = "wrongId" };
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            Action action = () => repository.Update(stubFood, stubFood.UserId);
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Delete_FoodFound_RemoveFoodFromDb()
        {
            Init();
            var idToDelete = 1;
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            repository.Delete(idToDelete, "abc");
            context.SaveChanges();

            var outputCollection = context.FoodItems.Where(x => x.Id == idToDelete);
            outputCollection.Should().HaveCount(0);
        }

        [Test]
        public void Delete_FoodOrUserIdNotFound_ThrowInvalidOperationException()
        {
            Init();
            using var context = new ApplicationDbContext(dbStructureInfo);
            repository = new FoodItemRepository(context);

            Action action = () => repository.Delete(-1, "abc");
            Action action2 = () => repository.Delete(1, "wrongId");

            action.Should().Throw<InvalidOperationException>();
            action2.Should().Throw<InvalidOperationException>();
        }

    }
}
