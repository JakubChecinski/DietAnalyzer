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
    class RestrictionControllerTests
    {
        private Mock<ILogger<RestrictionController>> mockLogger;
        private Mock<IRestrictionService> mockService;
        private RestrictionController controller;
        private string userId;
        private void Init()
        {
            mockLogger = new Mock<ILogger<RestrictionController>>();
            mockService = new Mock<IRestrictionService>();
            controller = new RestrictionController(mockLogger.Object, mockService.Object);
            userId = "abc";
            controller.MockCurrentUser(userId, "userName");
        }

        [Test]
        public void Manage_ActionCalled_ReturnRestrictionView()
        {
            Init();

            var result = controller.Manage() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<RestrictionViewModel>();
        }

        [Test]
        public void Manage_ActionCalled_UseGetToInitialize()
        {
            Init();
            var restrictions = new RestrictionUser();
            mockService.Setup(x => x.Get(userId)).Returns(restrictions);

            var result = controller.Manage() as ViewResult;

            mockService.Verify(x => x.Get(userId), Times.Once);
            var viewModel = (RestrictionViewModel)result.Model;
            viewModel.RestrictionInfo.Should().Be(restrictions);
        }

        [Test]
        public void ManagePost_InvalidState_ReturnManageView()
        {
            Init();
            var vm = new RestrictionViewModel();

            controller.ModelState.AddModelError("ErrorKey", "ErrorMessage");
            var result = controller.Manage(vm) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            result.Model.Should().BeOfType<RestrictionViewModel>();
        }

        [Test]
        public void ManagePost_ValidState_CallUpdate()
        {
            Init();
            var restrictions = new RestrictionUser();

            var result = controller.Manage(new RestrictionViewModel() { RestrictionInfo = restrictions });

            mockService.Verify(x => x.Update(restrictions), Times.Once);
        }

        [Test]
        public void ManagePost_ValidState_RedirectToDietList()
        {
            Init();

            var result = controller.Manage(new RestrictionViewModel());

            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirect = (RedirectToActionResult)result;
            redirect.ActionName.Should().Be("DietList");
            redirect.ControllerName.Should().Be("Diet");
        }

    }
}
