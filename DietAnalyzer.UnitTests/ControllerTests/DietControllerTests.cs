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
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.UnitTests.ControllerTests
{
    class DietControllerTests
    {
        private CustomMockLogger<DietController> mockLogger;
        private Mock<IDietService> mockService;
        private Mock<IFoodItemService> mockFoodService;
        private Mock<IEvaluationService> mockEvaluationService;
        private DietController controller;
        private string userId;
        private void Init()
        {
            mockLogger = new CustomMockLogger<DietController>();
            mockService = new Mock<IDietService>();
            mockFoodService = new Mock<IFoodItemService>();
            mockEvaluationService = new Mock<IEvaluationService>();
            controller = new DietController(mockLogger, mockService.Object,
                mockFoodService.Object, mockEvaluationService.Object);
            userId = "abc";

            controller.MockCurrentUser(userId, "userName");
            mockFoodService.Setup(x => x.Get(userId, It.IsAny<bool>())).Returns(new List<FoodItem>());
            mockFoodService.Setup(x => x.PrepareMeasuresForFoods(userId, It.IsAny<ICollection<DietItem>>()))
                .Returns(new List<List<Tuple<int, string>>>());
        }

        [Test]
        public void DietList_ActionCalled_ReturnDietListView()
        {
            Init();

            var result = controller.DietList() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<DietListViewModel>();
        }

        [Test]
        public void ManageDiet_ActionCalled_ReturnDietView()
        {
            Init();
            mockService.Setup(x => x.PrepareNewDiet(userId)).Returns(new Diet());

            var result = controller.ManageDiet() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<DietViewModel>();
        }

        [Test]
        public void ManageDiet_IdZero_UsePrepareNewDietToInitialize()
        {
            Init();
            var testDiet = new Diet() { Id = 1 };
            mockService.Setup(x => x.PrepareNewDiet(userId)).Returns(testDiet);

            var result = controller.ManageDiet() as ViewResult;

            mockService.Verify(x => x.PrepareNewDiet(userId), Times.Once);
            mockService.Verify(x => x.Get(userId, It.IsAny<int>()), Times.Never);
            var viewModel = (DietViewModel)result.Model;
            viewModel.Diet.Should().Be(testDiet);
        }

        [Test]
        public void ManageDiet_IdNonZero_UseGetToInitialize()
        {
            Init();
            int testId = 1;
            var testDiet = new Diet() { Id = 1 };
            mockService.Setup(x => x.Get(userId, testId)).Returns(testDiet);

            var result = controller.ManageDiet(testId) as ViewResult;

            mockService.Verify(x => x.PrepareNewDiet(userId), Times.Never);
            mockService.Verify(x => x.Get(userId, testId), Times.Once);
            var viewModel = (DietViewModel)result.Model;
            viewModel.Diet.Should().Be(testDiet);
        }

        [TestCase(0, true)]
        [TestCase(1, false)]
        public void ManageDiet_IdSupplied_SetIsAddAndNoFoodsValues(int id, bool valueToSet)
        {
            Init();
            mockService.Setup(x => x.PrepareNewDiet(userId)).Returns(new Diet());
            mockService.Setup(x => x.Get(userId, id)).Returns(new Diet());

            var result = controller.ManageDiet(id) as ViewResult;

            var viewModel = (DietViewModel)result.Model;
            viewModel.IsAdd.Should().Be(valueToSet);
            viewModel.NoFoodsOnList.Should().Be(valueToSet);
        }

        [Test]
        public void ManageDietPost_NoDietItems_RedirectToDietList()
        {
            Init();
            var vm = new DietViewModel();

            var result = controller.ManageDiet(vm);

            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirect = (RedirectToActionResult)result;
            redirect.ActionName.Should().Be("DietList");
            redirect.ControllerName.Should().Be("Diet");
        }

        [Test]
        public void ManageDietPost_InvalidState_ReturnDietView()
        {
            Init();
            var vm = TestObjects.GetDietViewModelForInvalidState(1);

            controller.ModelState.AddModelError("ErrorKey", "ErrorMessage");
            var result = controller.ManageDiet(vm) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<DietViewModel>();
        }

        [Test]
        public void ManageDietPost_InvalidState_ReloadElements()
        {
            Init();
            var foodId = 2;
            var testTuple = new Tuple<int, string>(3, "def");
            mockFoodService.Setup(x => x.PrepareMeasuresForFoods(userId, It.IsAny<ICollection<DietItem>>()))
                .Returns(new List<List<Tuple<int, string>>> { new List<Tuple<int, string>> { testTuple } });
            var vm = TestObjects.GetDietViewModelForInvalidState(foodId);

            controller.ModelState.AddModelError("ErrorKey", "ErrorMessage");
            var result = controller.ManageDiet(vm) as ViewResult;

            var vmAfter = (DietViewModel)result.Model;
            vmAfter.AvailableMeasuresForEachFood.First().First().Item1.Should().Be(testTuple.Item1);
            vmAfter.AvailableMeasuresForEachFood.First().First().Item2.Should().Be(testTuple.Item2);
            mockFoodService.Verify(x => x.Get(userId, foodId), Times.Once);
        }


        [Test]
        public void ManageDietPost_ValidStateIsAdd_CallAdd()
        {
            Init();
            var vm = TestObjects.GetValidDietViewModel(true);

            controller.ManageDiet(vm);

            mockService.Verify(x => x.Add(It.IsAny<Diet>()), Times.Once);
        }

        [Test]
        public void ManageDietPost_ValidStateIsUpdate_CallUpdate()
        {
            Init();
            var vm = TestObjects.GetValidDietViewModel(false);

            controller.ManageDiet(vm);

            mockService.Verify(x => x.Update(It.IsAny<Diet>(), userId, It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public void ManageDietPost_ValidState_RedirectToDietList()
        {
            Init();
            var vm = TestObjects.GetValidDietViewModel(false);

            var result = controller.ManageDiet(vm);

            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirect = (RedirectToActionResult)result;
            redirect.ActionName.Should().Be("DietList");
            redirect.ControllerName.Should().Be("Diet");
        }

        [Test]
        public void Delete_MethodCalled_CallDelete()
        {
            Init();
            int dietId = 1;
            controller.MockUrlAction("testUrl");

            controller.Delete(dietId);

            mockService.Verify(x => x.Delete(dietId, userId), Times.Once);
        }

        [Test]
        public void Delete_DeleteSuccessful_ReturnSuccessJson()
        {
            Init();
            int dietId = 1;
            controller.MockUrlAction("testUrl");

            var result = controller.Delete(dietId);

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
            int dietId = 1;
            mockService.Setup(x => x.Delete(dietId, userId)).Throws(new Exception());

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
            int dietId = 1;
            mockService.Setup(x => x.Delete(dietId, userId)).Throws(new Exception());

            var result = controller.Delete(1);

            mockLogger.LogDump.Should().Contain("Failed to delete diet");
        }

        [Test]
        public void Evaluate_MethodCalled_CallEvaluationService()
        {
            Init();
            int dietId = 1;
            Diet testDiet = new Diet { Id = dietId };
            mockService.Setup(x => x.GetWithDietItemChildren(userId, dietId)).Returns(testDiet);

            controller.Evaluate(dietId);

            mockEvaluationService.Verify(x => x.GetNutritions(testDiet), Times.Once);
            mockEvaluationService.Verify(x => x.GetSummary(testDiet), Times.Once);
        }

        [Test]
        public void Evaluate_MethodCalled_UpdateEvaluationData()
        {
            Init();
            int dietId = 1;
            Diet testDiet = new Diet { Id = dietId };
            mockService.Setup(x => x.GetWithDietItemChildren(userId, dietId)).Returns(testDiet);

            controller.Evaluate(dietId);

            mockService.Verify(x => x.Update(testDiet, userId, false), Times.Once);
        }

        [Test]
        public void Evaluate_MethodCalled_ReturnPartialView()
        {
            Init();
            int dietId = 1;
            Diet testDiet = new Diet { Id = dietId };
            mockService.Setup(x => x.GetWithDietItemChildren(userId, dietId)).Returns(testDiet);

            var result = controller.Evaluate(dietId) as PartialViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<Diet>();
        }

        [Test]
        public void Evaluate_WrongId_LogErrorAndReturnString()
        {
            Init();

            var result = controller.Evaluate(1) as ContentResult;

            result.Should().NotBeNull();
            result.Content.Should().NotBeNull();
            mockLogger.LogDump.Should().Contain("Diet with this id does not exist");
        }

        [Test]
        public void AddNewPosition_MethodCalled_ReturnPartialView()
        {
            Init();
            int foodId = 1;
            mockFoodService.Setup(x => x.Get(userId, foodId)).Returns(new FoodItem());

            var result = controller.AddNewPosition(1, 1, foodId) as PartialViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<DietItemRowViewModel>();
        }

    }
}
