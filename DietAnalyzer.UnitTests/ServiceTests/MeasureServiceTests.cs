using DietAnalyzer.Data;
using DietAnalyzer.Data.Repositories;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DietAnalyzer.UnitTests.ServiceTests
{
    class MeasureServiceTests
    {
        private Mock<IUnitOfWork> mockUoW;
        private MeasureService service;
        private Measure measure, measureCustom;
        private string userId;
        private void Init()
        {
            mockUoW = new Mock<IUnitOfWork>();
            service = new MeasureService(mockUoW.Object);
            userId = "abc";
            measure = TestObjects.GetMeasureWithId(1, userId: null);
            measureCustom = TestObjects.GetMeasureWithId(2, userId);

            mockUoW.Setup(x => x.Measures.Get(userId)).Returns(new List<Measure> { measure, measureCustom });
            mockUoW.Setup(x => x.Measures.GetCustom(userId)).Returns(new List<Measure> { measureCustom });
            mockUoW.Setup(x => x.Measures.Get(measure.Id)).Returns(measure);
        }

        [Test]
        public void Get_CorrectUserId_ReturnMeasures()
        {
            Init();

            var result = service.Get(userId);

            result.Should().HaveCount(2);
            result.Any(x => x.Id == measure.Id).Should().BeTrue();
        }

        [Test]
        public void Get_IncorrectUserId_ReturnEmptyCollection()
        {
            Init();

            var result = service.Get("wrongId");

            result.Should().HaveCount(0);
        }

        [Test]
        public void GetCustom_CorrectUserId_ReturnCustomMeasures()
        {
            Init();

            var result = service.GetCustom(userId);

            result.Should().HaveCount(1);
            result.First().Id.Should().Be(measureCustom.Id);
        }

        [Test]
        public void GetCustom_IncorrectUserId_ReturnEmptyCollection()
        {
            Init();

            var result = service.GetCustom("wrongId");

            result.Should().HaveCount(0);
        }

        [Test]
        public void Get_MeasureFound_ReturnMeasure()
        {
            Init();

            var result = service.Get(measure.Id);

            result.Id.Should().Be(measure.Id);
        }

        [Test]
        public void Get_MeasureNotFound_ReturnNull()
        {
            Init();

            var result = service.Get(-1);

            result.Should().BeNull();
        }

        [Test]
        public void Update_MeasureToSimplyUpdate_CallUpdate()
        {
            Init();
            var measureToUpdateOld = TestObjects.GetMeasureWithId(3, userId);
            var measureToUpdateNew = TestObjects.GetMeasureWithId(3, userId);
            var oldMeasures = new List<Measure> { measureToUpdateOld };
            var newMeasures = new List<Measure> { measureToUpdateNew };
            mockUoW.Setup(x => x.Measures.GetCustom(userId)).Returns(oldMeasures);

            service.Update(newMeasures, userId);

            mockUoW.Verify(x => x.Measures.Update(measureToUpdateNew, userId), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_MeasureToAddWhileUpdating_CallAdds()
        {
            Init();
            var measureToAddWhileUpdating = TestObjects.GetMeasureWithId(3, userId);
            var oldMeasures = new List<Measure> { };
            var newMeasures = new List<Measure> { measureToAddWhileUpdating };
            mockUoW.Setup(x => x.Measures.GetCustom(userId)).Returns(new List<Measure> { });
            mockUoW.Setup(x => x.Foods.Get(userId)).Returns(new List<FoodItem> { new FoodItem { Id = 1 } });
            mockUoW.Setup(x => x.FoodMeasures).Returns(new Mock<IFoodMeasureRepository>().Object);

            service.Update(newMeasures, userId);

            mockUoW.Verify(x => x.Measures.Add(measureToAddWhileUpdating), Times.Once);
            mockUoW.Verify(x => x.FoodMeasures.Add(measureToAddWhileUpdating.Id, 1), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void Update_MeasureToDeleteWhileUpdating_CallDeletes()
        {
            Init();
            var measureToDeleteWhileUpdating = TestObjects.GetMeasureWithId(3, userId);
            var oldMeasures = new List<Measure> { measureToDeleteWhileUpdating };
            var newMeasures = new List<Measure> { };
            mockUoW.Setup(x => x.Measures.GetCustom(userId)).Returns(oldMeasures);
            mockUoW.Setup(x => x.FoodMeasures).Returns(new Mock<IFoodMeasureRepository>().Object);
            mockUoW.Setup(x => x.DietItems).Returns(new Mock<IDietItemRepository>().Object);


            service.Update(newMeasures, userId);

            mockUoW.Verify(x => x.Measures.Delete(measureToDeleteWhileUpdating.Id, userId), Times.Once);
            mockUoW.Verify(x => x.FoodMeasures
                .Delete(measureToDeleteWhileUpdating.FoodItems.First().Id), Times.Once);
            mockUoW.Verify(x => x.DietItems
                .Delete(measureToDeleteWhileUpdating.DietItems.First()), Times.Once);
            mockUoW.Verify(x => x.Save(), Times.AtLeastOnce);
        }

        [Test]
        public void ReloadMeasures_FoodMeasuresSupplied_ReturnThemWithMeasures()
        {
            Init();
            var foodMeasures = new List<FoodMeasure>
            {
                new FoodMeasure { Id = 1, MeasureId = measure.Id }
            };

            var result = service.ReloadMeasures(foodMeasures);

            result.First().Measure.Should().Be(measure);
        }

    }
}
