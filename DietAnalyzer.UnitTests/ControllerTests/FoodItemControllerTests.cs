using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
using DietAnalyzer.UnitTests.Extensions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace DietAnalyzer.UnitTests.ControllerTests
{
    class FoodItemControllerTests
    {
        // note: image processing is not covered in the tests here
        // therefore, the image helper object is essentially a dummy and will never be used 
        // (but it must be provided to make the compiler happy)
        private CustomMockLogger<FoodItemController> mockLogger;
        private CustomMockLogger<ImageHelper> mockImageLogger;
        private ImageHelper imageHelper;
        private Mock<IMeasureService> mockMeasureService;
        private Mock<IFoodItemService> mockService;
        private FoodItemController controller;
        private string userId;
        private void Init()
        {
            mockLogger = new CustomMockLogger<FoodItemController>();
            mockImageLogger = new CustomMockLogger<ImageHelper>();
            imageHelper = new ImageHelper(mockImageLogger);
            mockMeasureService = new Mock<IMeasureService>();
            mockService = new Mock<IFoodItemService>();
            controller = new FoodItemController(mockLogger, mockService.Object,
                mockMeasureService.Object, imageHelper);
            userId = "abc";
            controller.MockCurrentUser(userId, "userName");
        }

        [Test]
        public void FoodList_ActionCalled_ReturnFoodListView()
        {
            Init();

            var result = controller.FoodList() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<FoodListViewModel>();
        }

        [Test]
        public void ManageFood_ActionCalled_ReturnFoodView()
        {
            Init();
            mockService.Setup(x => x.PrepareNewFood(userId)).Returns(new FoodItem());

            var result = controller.ManageFood() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<FoodItemViewModel>();
        }

        [Test]
        public void ManageFood_IdZero_UsePrepareNewFoodToInitialize()
        {
            Init();
            FoodItem testFood = new FoodItem() { Id = 1 };
            mockService.Setup(x => x.PrepareNewFood(userId)).Returns(testFood);

            var result = controller.ManageFood() as ViewResult;

            mockService.Verify(x => x.PrepareNewFood(userId), Times.Once);
            mockService.Verify(x => x.Get(userId, It.IsAny<int>()), Times.Never);
            var viewModel = (FoodItemViewModel)result.Model;
            viewModel.FoodItem.Should().Be(testFood);
        }

        [Test]
        public void ManageFood_IdNonZero_UseGetToInitialize()
        {
            Init();
            int testId = 1;
            FoodItem testFood = new FoodItem() { Id = 1 };
            mockService.Setup(x => x.Get(userId, testId)).Returns(testFood);

            var result = controller.ManageFood(testId) as ViewResult;

            mockService.Verify(x => x.PrepareNewFood(userId), Times.Never);
            mockService.Verify(x => x.Get(userId, testId), Times.Once);
            var viewModel = (FoodItemViewModel)result.Model;
            viewModel.FoodItem.Should().Be(testFood);
        }

        [TestCase(0, true)]
        [TestCase(1, false)]
        public void ManageFood_IdSupplied_SetValuesOfViewModekHelperProperties(int id, bool valueToSet)
        {
            Init();
            mockService.Setup(x => x.PrepareNewFood(userId)).Returns(new FoodItem());
            mockService.Setup(x => x.Get(userId, id)).Returns(new FoodItem());

            var result = controller.ManageFood(id) as ViewResult;

            var viewModel = (FoodItemViewModel)result.Model;
            viewModel.IsAdd.Should().Be(valueToSet);
            viewModel.HasImageProblem.Should().BeFalse();
            viewModel.HasMeasureProblem.Should().BeFalse();
        }

        [Test]
        public void ManageFoodPost_InvalidState_ReturnFoodItemView()
        {
            Init();
            var vm = new FoodItemViewModel();

            controller.ModelState.AddModelError("ErrorKey", "ErrorMessage");
            var result = controller.ManageFood(vm) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<FoodItemViewModel>();
        }


        [Test]
        public void ManageFoodPost_HasMeasureProblem_ReturnFoodItemView()
        {
            Init();
            var vm = TestObjects.GetValidFoodViewModel(true);

            var result = controller.ManageFood(vm) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<FoodItemViewModel>();
        }

        [Test]
        public void ManageFoodPost_HasMeasureProblem_SetMeasureProblemInfo()
        {
            Init();
            var vm = TestObjects.GetValidFoodViewModel(true);

            var result = controller.ManageFood(vm) as ViewResult;

            var viewModel = (FoodItemViewModel)result.Model;
            viewModel.HasMeasureProblem.Should().BeTrue();
        }

        [Test]
        public void ManageFoodPost_ValidStateIsAdd_CallAdd()
        {
            Init();
            var vm = TestObjects.GetValidFoodViewModel(false, isAdd: true);

            var result = controller.ManageFood(vm) as ViewResult;

            mockService.Verify(x => x.Add(It.IsAny<FoodItem>()), Times.Once);
        }

        [Test]
        public void ManageFoodPost_ValidStateIsUpdate_CallUpdate()
        {
            Init();
            var vm = TestObjects.GetValidFoodViewModel(false, isAdd: false);

            var result = controller.ManageFood(vm) as ViewResult;

            mockService.Verify(x => x.Update(It.IsAny<FoodItem>(), userId), Times.Once);
        }

        [Test]
        public void ManageFoodPost_ValidState_RedirectToFoodList()
        {
            Init();
            var vm = TestObjects.GetValidFoodViewModel(false);

            var result = controller.ManageFood(vm);

            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirect = (RedirectToActionResult)result;
            redirect.ActionName.Should().Be("FoodList");
            redirect.ControllerName.Should().Be("FoodItem");
        }

        [Test]
        public void Delete_MethodCalled_CallDelete()
        {
            Init();
            int foodId = 1;
            controller.MockUrlAction("testUrl");

            controller.Delete(foodId);

            mockService.Verify(x => x.Delete(foodId, userId), Times.Once);
        }

        [Test]
        public void Delete_DeleteSuccessful_ReturnSuccessJson()
        {
            Init();
            int foodId = 1;
            controller.MockUrlAction("testUrl");

            var result = controller.Delete(foodId);

            result.Should().BeAssignableTo<JsonResult>();
            dynamic json = (JsonResult)result;
            bool isSuccess = json.Value.GetType().GetProperty("success").GetValue(json.Value);
            isSuccess.Should().Be(true);
            string url = json.Value.GetType().GetProperty("redirectToUrl").GetValue(json.Value);
            url.Should().Be("testUrl");
        }

        [Test]
        public void Delete_DeleteUnsuccessful_ReturnFailureJson()
        {
            Init();
            int foodId = 1;
            mockService.Setup(x => x.Delete(foodId, userId)).Throws(new Exception());

            var result = controller.Delete(1);

            result.Should().BeAssignableTo<JsonResult>();
            dynamic json = (JsonResult)result;
            bool isSuccess = json.Value.GetType().GetProperty("success").GetValue(json.Value);
            isSuccess.Should().Be(false);
        }

        [Test]
        public void Delete_DeleteUnsuccessful_LogError()
        {
            Init();
            int foodId = 1;
            mockService.Setup(x => x.Delete(foodId, userId)).Throws(new Exception());

            var result = controller.Delete(1);

            mockLogger.LogDump.Should().Contain("Failed to delete food");
        }

        [Test]
        public void GetDeleteConfirmMessage_DietsFound_ReturnJsonInfo()
        {
            Init();
            int foodId = 1;
            mockService.Setup(x => x.GetDietsWithThisFood(foodId, userId)).Returns("abc");

            var result = controller.GetDeleteConfirmMessage(foodId);

            result.Should().BeAssignableTo<JsonResult>();
            dynamic json = (JsonResult)result;
            string message = json.Value.GetType().GetProperty("message").GetValue(json.Value);
            message.Should().Contain("abc");
        }

        [Test]
        public void GetDeleteConfirmMessage_DietsNotFound_ReturnJsonInfo()
        {
            Init();
            int foodId = 1;
            mockService.Setup(x => x.GetDietsWithThisFood(foodId, userId)).Returns("");

            var result = controller.GetDeleteConfirmMessage(foodId);

            result.Should().BeAssignableTo<JsonResult>();
            dynamic json = (JsonResult)result;
            string message = json.Value.GetType().GetProperty("message").GetValue(json.Value);
            message.Should().NotBeEmpty();
        }

        [Test]
        public void GetDeleteConfirmMessage_ExceptionOccurred_ReturnJsonInfo()
        {
            Init();
            int foodId = 1;
            mockService.Setup(x => x.GetDietsWithThisFood(foodId, userId)).Throws(new Exception());

            var result = controller.GetDeleteConfirmMessage(foodId);

            result.Should().BeAssignableTo<JsonResult>();
            dynamic json = (JsonResult)result;
            string message = json.Value.GetType().GetProperty("message").GetValue(json.Value);
            message.Should().NotBeEmpty();
        }

    }
}
