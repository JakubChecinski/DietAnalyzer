using DietAnalyzer.Data;
using DietAnalyzer.Services;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.UnitTests.Extensions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietAnalyzer.Data.Repositories;
using DietAnalyzer.Models.ViewModels;

namespace DietAnalyzer.UnitTests.ServiceTests
{
    class FoodItemServiceTests
    {
        private Mock<IUnitOfWork> mockUoW;
        private Mock<IMeasureService> mockMeasureService;
        private Mock<IRestrictionService> mockRestrictionService;
        private FoodItemService service;
        private FoodItem food, foodCustom, foodRestricted, foodCustomRestricted;
        private string userId;
        private void Init()
        {
            mockUoW = new Mock<IUnitOfWork>();
            mockMeasureService = new Mock<IMeasureService>();
            mockRestrictionService = new Mock<IRestrictionService>();
            service = new FoodItemService(mockUoW.Object, 
                mockMeasureService.Object, mockRestrictionService.Object);
            food = TestObjects.GetFood(FoodType.Normal);
            foodCustom = TestObjects.GetFood(FoodType.Custom);
            foodRestricted = TestObjects.GetFood(FoodType.Restricted);
            foodCustomRestricted = TestObjects.GetFood(FoodType.CustomRestricted);

            mockUoW.Setup(x => x.Foods).Returns(new Mock<IFoodItemRepository>().Object);
            mockUoW.Setup(x => x.RestrictionFoods).Returns(new Mock<IRestrictionFoodRepository>().Object);
            mockUoW.Setup(x => x.NutritionFoods).Returns(new Mock<INutritionFoodRepository>().Object);
            mockUoW.Setup(x => x.FoodMeasures).Returns(new Mock<IFoodMeasureRepository>().Object);
            mockUoW.Setup(x => x.DietItems).Returns(new Mock<IDietItemRepository>().Object);
            mockUoW.Setup(x => x.Diets).Returns(new Mock<IDietRepository>().Object);

            
        }

        [Test]
        public void Get_SuitableOnlyFalse_ReturnAllFoods()
        {
            Init();
            mockUoW.Setup(x => x.Foods.Get(userId)).Returns(
                new List<FoodItem> { food, foodCustom, foodRestricted, foodCustomRestricted });

            var result = service.Get(userId, false);

            result.Should().HaveCount(4);
        }

        [Test]
        public void Get_SuitableOnlyTrue_ReturnOnlySuitableFoods()
        {
            Init();
            var userRestriction = new RestrictionUser { Diabetes = true };
            mockUoW.Setup(x => x.Foods.Get(userId, userRestriction)).Returns(
                new List<FoodItem> { food, foodCustom });
            mockRestrictionService.Setup(x => x.Get(userId)).Returns(userRestriction);

            var result = service.Get(userId, true);

            result.Should().HaveCount(2);
        }

        [Test]
        public void GetCustom_SuitableOnlyFalse_ReturnOnlyCustomFoods()
        {
            Init();
            mockUoW.Setup(x => x.Foods.GetCustom(userId)).Returns(
                new List<FoodItem> { foodCustom, foodCustomRestricted });

            var result = service.GetCustom(userId, false);

            result.Should().HaveCount(2);
        }

        [Test]
        public void GetCustom_SuitableOnlyTrue_ReturnOnlyCustomAndSuitableFoods()
        {
            Init();
            var userRestriction = new RestrictionUser { Diabetes = true };
            mockUoW.Setup(x => x.Foods.GetCustom(userId, userRestriction)).Returns(
                new List<FoodItem> { foodCustom });
            mockRestrictionService.Setup(x => x.Get(userId)).Returns(userRestriction);

            var result = service.GetCustom(userId, true);

            result.Should().HaveCount(1);
        }

        [Test]
        public void Get_FoodFound_ReturnFood()
        {
            Init();
            mockUoW.Setup(x => x.Foods.Get(userId, foodCustom.Id)).Returns(foodCustom); 

            var result = service.Get(userId, foodCustom.Id);

            result.Id.Should().Be(foodCustom.Id);
            result.UserId.Should().Be(foodCustom.UserId);
        }

        [Test]
        public void Get_FoodNotFound_ReturnNull()
        {
            Init();
            var result = service.Get(userId, -1);
            result.Should().BeNull();
            result = service.Get("wrongId", 1);
            result.Should().BeNull();
        }

        [Test]
        public void PrepareMeasuresForFood_FoodFound_ReturnTupleWithLinkedMeasures()
        {
            Init();
            var foodWithMeasures = TestObjects.GetFood(FoodType.NormalWithMeasures);
            mockUoW.Setup(x => x.Foods.Get(userId, 5)).Returns(foodWithMeasures);

            var result = service.PrepareMeasuresForFood(userId, 5);

            result.Should().BeOfType<List<Tuple<int, string>>>();
            result.Should().HaveCount(1);
            result.First().Item1.Should().Be(1);
            result.First().Item2.Should().Be("linked");
        }

        [Test]
        public void PrepareMeasuresForFood_FoodNotFound_ThrowNullReferenceException()
        {
            Init();

            Action action = () => service.PrepareMeasuresForFood(userId, -1);
            Action action2 = () => service.PrepareMeasuresForFood("wrongId", 1);
            action.Should().Throw<NullReferenceException>();
            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void PrepareMeasuresForFoods_DietItemsSupplied_ReturnMeasures()
        {
            Init();
            var foodWithMeasures = TestObjects.GetFood(FoodType.NormalWithMeasures);
            mockUoW.Setup(x => x.Foods.Get(userId, 5)).Returns(foodWithMeasures);
            var dietItems = new List<DietItem> { new DietItem { Id = 1, FoodItemId = foodWithMeasures.Id } };

            var result = service.PrepareMeasuresForFoods(userId, dietItems);

            result.Should().BeOfType<List<List<Tuple<int, string>>>>();
            result.Should().HaveCount(1);
            result.First().First().Item1.Should().Be(1);
            result.First().First().Item2.Should().Be("linked");
        }

        [Test]
        public void PrepareMeasuresForFoods_DietItemsEmpty_ReturnNull()
        {
            Init();

            var result = service.PrepareMeasuresForFoods(userId, null);

            result.Should().BeNull();
        }

        [Test]
        public void PrepareNewFood_UserIdGiven_ReturnFoodWithThisUserId()
        {
            Init();
            mockMeasureService.Setup(x => x.Get("def")).Returns(new List<Measure>());

            var result = service.PrepareNewFood("def");

            result.Should().BeOfType<FoodItem>();
            result.UserId.Should().Be("def");
        }

        [Test]
        public void Add_FoodGiven_CallAddsAndSaveOnUoW()
        {
            Init();
            var testFood = TestObjects.GetFood(FoodType.NormalWithAllElements);

            service.Add(testFood);

            mockUoW.Verify(x => x.Foods.Add(testFood), Times.Once);
            mockUoW.Verify(x => x.NutritionFoods.Add(testFood.Nutrition), Times.Once);
            mockUoW.Verify(x => x.RestrictionFoods.Add(testFood.Restrictions), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Add_FoodIsNull_ThrowArgumentNullException()
        {
            Init();

            Action action = () => service.Add(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Update_FoodAndUserIdGiven_CallUpdatesAndSaveOnUoW()
        {
            Init();
            var testFood = TestObjects.GetFood(FoodType.NormalWithAllElements);

            service.Update(testFood, userId);

            mockUoW.Verify(x => x.Foods.Update(testFood, userId), Times.Once);
            mockUoW.Verify(x => x.NutritionFoods.Update(testFood.Nutrition), Times.Once);
            mockUoW.Verify(x => x.RestrictionFoods.Update(testFood.Restrictions), Times.Once);
            mockUoW.Verify(x => x.FoodMeasures.Update(It.IsAny<FoodMeasure>()), Times.AtLeastOnce);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_FoodIsNull_ThrowArgumentNullException()
        {
            Init();

            Action action = () => service.Update(null, userId);
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Delete_DietAndUserIdsGiven_CallDeletesAndSaveOnUoW()
        {
            Init();
            var testFood = TestObjects.GetFood(FoodType.NormalWithAllElements);
            mockUoW.Setup(x => x.Foods.Get(userId, testFood.Id)).Returns(testFood);

            service.Delete(testFood.Id, userId);

            mockUoW.Verify(x => x.Foods.Delete(testFood.Id, userId), Times.Once);
            mockUoW.Verify(x => x.FoodMeasures.Delete(testFood.Measures.First().Id), Times.Once);
            mockUoW.Verify(x => x.DietItems.Delete(testFood.DietItems.First()), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Delete_DietAndUserIdsGiven_CleanUpEmptyDiets()
        {
            Init();
            var testFood = TestObjects.GetFood(FoodType.NormalWithAllElements);
            mockUoW.Setup(x => x.Foods.Get(userId, testFood.Id)).Returns(testFood);
            var emptyDiet = new Diet { Id = 1 };
            mockUoW.Setup(x => x.Diets.Get(userId)).Returns(new List<Diet> { emptyDiet });

            service.Delete(testFood.Id, userId);

            mockUoW.Verify(x => x.Diets.Delete(emptyDiet.Id, userId), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void AssignDietItems_GetViewModel_AssignDietItems()
        {
            Init();
            var measuresBefore = new List<FoodMeasure>();
            var measuresAfter = new List<FoodMeasure>();
            var vm = TestObjects.GetFoodViewModel(measuresBefore);
            mockMeasureService.Setup(x => x.ReloadMeasures(measuresBefore)).Returns(measuresAfter);

            service.AssignFoodItemData(vm, userId);

            vm.FoodItem.UserId.Should().Be(userId);
            vm.FoodItem.Measures.Should().BeEquivalentTo(measuresAfter);
        }

    }
}
