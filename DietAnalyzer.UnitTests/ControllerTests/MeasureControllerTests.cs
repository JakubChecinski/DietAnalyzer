using DietAnalyzer.Data;
using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.UnitTests.Extensions;
using Microsoft.Extensions.Logging;
using DietAnalyzer.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DietAnalyzer.Models.ViewModels;

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
        public void ManagePost_ValidState_RedirectToDietList()
        {
            Init();

            var result = controller.Manage(new MeasureViewModel());

            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirect = (RedirectToActionResult)result;
            redirect.ActionName.Should().Be("DietList");
            redirect.ControllerName.Should().Be("Diet");
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
