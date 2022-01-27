using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.UnitTests.Extensions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DietAnalyzer.UnitTests.ControllerTests
{
    class MeasureControllerTests
    {
        private Mock<ILogger<MeasureController>> mockLogger;
        private Mock<IMeasureService> mockService;
        private MeasureController controller;
        private string userId;
        private void Init()
        {
            mockLogger = new Mock<ILogger<MeasureController>>();
            mockService = new Mock<IMeasureService>();
            controller = new MeasureController(mockLogger.Object, mockService.Object);
            userId = "abc";
            controller.MockCurrentUser(userId, "userName");
        }

        [Test]
        public void Manage_ActionCalled_ReturnMeasureView()
        {
            Init();

            var result = controller.Manage() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<MeasureViewModel>();
        }

        [Test]
        public void Manage_ActionCalled_UseGetCustomToInitialize()
        {
            Init();
            var customMeasures = new List<Measure>();
            mockService.Setup(x => x.GetCustom(userId)).Returns(customMeasures);

            var result = controller.Manage() as ViewResult;

            mockService.Verify(x => x.GetCustom(userId), Times.Once);
            var viewModel = (MeasureViewModel)result.Model;
            viewModel.Measures.Should().BeEquivalentTo(customMeasures);
        }

        [Test]
        public void ManagePost_InvalidState_ReturnManageView()
        {
            Init();
            var vm = new MeasureViewModel();

            controller.ModelState.AddModelError("ErrorKey", "ErrorMessage");
            var result = controller.Manage(vm) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<MeasureViewModel>();
        }

        [Test]
        public void ManagePost_ValidState_CallUpdate()
        {
            Init();
            var measures = new List<Measure>();

            var result = controller.Manage(new MeasureViewModel() { Measures = measures });

            mockService.Verify(x => x.Update(measures, userId), Times.Once);
        }

        [Test]
        public void ManagePost_ValidState_RedirectToAction()
        {
            Init();

            var result = controller.Manage(new MeasureViewModel());

            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
        }

        [Test]
        public void AddNewUnit_MethodCalled_ReturnPartialView()
        {
            Init();
            int index = 1;

            var result = controller.AddNewUnit(index) as PartialViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().Be(index);
        }


    }
}
