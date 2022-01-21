using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using DietAnalyzer.Services;
using DietAnalyzer.UnitTests.Extensions;
using Microsoft.AspNetCore.Mvc;
using DietAnalyzer.Services.Utilities;

namespace DietAnalyzer.IntegrationTests.CrossDomain
{
    class DietAndMeasureTests : IntegrationTests
    {
        private DietController dietController;

        public void Init()
        {
            dietController = controllerFactory.GetDietController();
        }

        [Test]
        public void DietItem_OnlyShowMeasuresLinkedToFood()
        {
            Init();
            VerifyTestAssumptions();

            var result = dietController.ManageDiet(medDietId) as ViewResult;

            var juiceIndex = (result.Model as DietViewModel).DietItems
                .FindIndex(x => x.FoodItemId == orangeJuiceId);
            var measuresForJuice = (result.Model as DietViewModel).AvailableMeasuresForEachFood[juiceIndex];
            measuresForJuice.Where(x => x.Item2 == "cups").Should().HaveCount(1);
            measuresForJuice.Where(x => x.Item2 == "teaspoons").Should().HaveCount(0);
        }

        private void VerifyTestAssumptions()
        {
            var cups = foodService.Get(userId, orangeJuiceId).Measures
                .Single(x => x.Measure.Name == "cups");
            var spoons = foodService.Get(userId, orangeJuiceId).Measures
                .Single(x => x.Measure.Name == "teaspoons");
            if (cups.IsCurrentlyLinked == false || spoons.IsCurrentlyLinked == true)
                throw new Exception("Test assumptions failed! Please verify food-measure links.");
        }

    }
}
