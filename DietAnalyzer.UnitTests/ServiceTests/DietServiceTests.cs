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
using DietAnalyzer.Models.ViewModels;

namespace DietAnalyzer.UnitTests.ServiceTests
{
    class DietServiceTests
    {
        private Mock<IUnitOfWork> mockUoW;
        private Mock<IFoodItemService> mockFoodService;
        private DietService service;  
        private Diet testDiet;
        private string userId;

        private void Init()
        {
            mockUoW = new Mock<IUnitOfWork>();
            mockFoodService = new Mock<IFoodItemService>();
            service = new DietService(mockUoW.Object, mockFoodService.Object);
            testDiet = TestObjects.GetDiet();
            userId = "abc";

            mockUoW.Setup(x => x.Diets.Get(userId)).Returns(new List<Diet> { testDiet });
            mockUoW.Setup(x => x.Diets.Get(userId, testDiet.Id)).Returns(testDiet);
            mockUoW.Setup(x => x.Diets.GetWithDietItemChildren(userId, testDiet.Id)).Returns(testDiet);
        }

        [Test]
        public void Get_CorrectUserId_ReturnUserDiets()
        {
            Init();

            var result = service.Get(userId);

            result.Should().HaveCount(1);
            result.First().Id.Should().Be(testDiet.Id);
        }

        [Test]
        public void Get_IncorrectUserId_ReturnEmptyCollection()
        {
            Init();

            var result = service.Get("wrongId");

            result.Should().HaveCount(0);
        }

        [Test]
        public void GetIncompatibleDietIds_SomeDietItemsAreNotCompatible_ReturnDietId()
        {
            Init();
            mockFoodService.Setup(x => x.Get(userId, true)).Returns(new List<FoodItem>()
            {
                new FoodItem { Id = 1 }
            });

            var result = service.GetIncompatibleDietIds(userId);

            result.Should().HaveCount(1);
            result.First().Should().Be(1);
        }

        [Test]
        public void GetIncompatibleDietIds_AllDietItemsAreCompatible_DontReturnDietId()
        {
            Init();
            mockFoodService.Setup(x => x.Get(userId, true)).Returns(new List<FoodItem>() 
            { 
                new FoodItem { Id = 1 },
                new FoodItem { Id = 2 }
            });

            var result = service.GetIncompatibleDietIds(userId);

            result.Should().HaveCount(0);
        }

        [Test]
        public void GetIncompatibleDietIds_IncorrectUserId_ReturnEmptyCollection()
        {
            Init();

            var result = service.GetIncompatibleDietIds("wrongId");

            result.Should().HaveCount(0);
        }

        [Test]
        public void Get_DietFound_ReturnDiet()
        {
            Init();

            var result = service.Get(userId, testDiet.Id);

            result.Id.Should().Be(testDiet.Id);
        }

        [Test]
        public void Get_DietNotFound_ReturnNull()
        {
            Init();

            var result = service.Get(userId, -1);
            var result2 = service.Get("wrongId", testDiet.Id);

            result.Should().BeNull();
            result2.Should().BeNull();
        }

        [Test]
        public void GetWithDietItemChildren_DietFound_ReturnDiet()
        {
            Init();

            var result = service.GetWithDietItemChildren(userId, testDiet.Id);

            result.Id.Should().Be(testDiet.Id);
        }

        [Test]
        public void GetWithDietItemChildren_DietNotFound_ReturnNull()
        {
            Init();

            var result = service.GetWithDietItemChildren(userId, -1);
            var result2 = result = service.Get("wrongId", testDiet.Id);

            result.Should().BeNull();
            result2.Should().BeNull();
        }

        [Test]
        public void PrepareNewDiet_UserIdGiven_ReturnDietWithThisUserId()
        {
            Init();

            var result = service.PrepareNewDiet("def");

            result.Should().BeOfType<Diet>();
            result.UserId.Should().Be("def");
        }

        [Test]
        public void Add_DietGiven_CallAddAndSaveOnUoW()
        {
            Init();

            service.Add(testDiet);

            mockUoW.Verify(x => x.Diets.Add(testDiet), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Add_DietIsNull_ThrowArgumentNullException()
        {
            Init();

            Action action = () => service.Add(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Update_DietAndUserIdGiven_CallUpdateAndSaveOnUoW()
        {
            Init();

            service.Update(testDiet, userId, false);

            mockUoW.Verify(x => x.Diets.Update(testDiet, userId), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_UpdateItemsTrue_RemoveOldItems()
        {
            Init();
            var oldItem = new DietItem() { Id = 5 };
            mockUoW.Setup(x => x.DietItems.Get(testDiet.Id)).Returns(new List<DietItem> { oldItem });

            service.Update(testDiet, userId, true);

            mockUoW.Verify(x => x.DietItems.Delete(oldItem), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_UpdateItemsTrue_AddNewItems()
        {
            Init();
            var newItem = testDiet.DietItems.First();
            mockUoW.Setup(x => x.DietItems.Get(testDiet.Id)).Returns(new List<DietItem> { });

            service.Update(testDiet, userId, true);

            mockUoW.Verify(x => x.DietItems.Add(newItem), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_UpdateItemsFalse_DontModifyItems()
        {
            Init();

            service.Update(testDiet, userId, false);

            mockUoW.Verify(x => x.DietItems.Delete(It.IsAny<DietItem>()), Times.Never);
            mockUoW.Verify(x => x.DietItems.Add(It.IsAny<DietItem>()), Times.Never);
        }

        [Test]
        public void Update_DietIsNull_ThrowArgumentNullException()
        {
            Init();

            Action action = () => service.Update(null, userId, false);
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Delete_DietAndUserIdsGiven_CallDeleteAndSaveOnUoW()
        {
            Init();

            service.Delete(testDiet.Id, userId);

            mockUoW.Verify(x => x.Diets.Delete(testDiet.Id, userId), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void AssignDietItems_GetViewModel_AssignDietItems()
        {
            Init();
            var vm = TestObjects.GetDietViewModel();

            service.AssignDietItems(vm);

            vm.DietItems.First().FoodItem.Should().BeNull();
            vm.Diet.DietItems.Should().BeEquivalentTo(vm.DietItems);
        }

    }
}
