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

namespace DietAnalyzer.UnitTests.ServiceTests
{
    class RestrictionServiceTests
    {
        private Mock<IUnitOfWork> mockUoW;
        private RestrictionService service;
        private RestrictionUser testRestrictions;
        private string userId;
        private void Init()
        {
            mockUoW = new Mock<IUnitOfWork>();
            service = new RestrictionService(mockUoW.Object);
            testRestrictions = new RestrictionUser { Id = 1 };
            userId = "abc";

            mockUoW.Setup(x => x.RestrictionUsers.Get(userId)).Returns(testRestrictions);
        }

        [Test]
        public void Get_RestrictionsExist_ReturnRestrictions()
        {
            Init();

            var result = service.Get(userId);

            result.Id.Should().Be(testRestrictions.Id);
        }

        [Test]
        public void Get_RestrictionsDontExist_CreateAndReturnNewRestrictions()
        {
            Init();

            var result = service.Get("wrongId");

            result.Should().NotBeNull();
            mockUoW.Verify(x => x.RestrictionUsers.Add(It.IsAny<RestrictionUser>()), Times.Once);
        }

        [Test]
        public void Update_RestrictionsGiven_CallUpdateAndSaveOnUoW()
        {
            Init();

            service.Update(testRestrictions);

            mockUoW.Verify(x => x.RestrictionUsers.Update(testRestrictions), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_RestrictionsAreNull_ThrowArgumentNullException()
        {
            Init();

            Action action = () => service.Update(null);
            action.Should().Throw<ArgumentNullException>();
        }

    }
}
