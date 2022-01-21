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

namespace DietAnalyzer.IntegrationTests.CrossDomain
{
    class DietAndRestrictionTests : IntegrationTests
    {
        private DietController dietController;
        public void Init()
        {
            dietController = controllerFactory.GetDietController();
            AddCustomRestrictionsToDb();
        }

        [Test]
        public void FoodRestricted_DontShowFoodAsAvailable()
        {
            Init();

            var result = dietController.ManageDiet(0) as ViewResult;

            var foodsShownToUser = (result.Model as DietViewModel).AvailableFoods;
            foodsShownToUser.Where(x => x.Name.Contains("chicken")).Should().HaveCount(0);
            foodsShownToUser.Where(x => x.Name.Contains("salmon")).Should().HaveCount(0);
            foodsShownToUser.Where(x => x.Name.Contains("spinach")).Should().HaveCount(1);
        }

        [Test]
        public void FoodRestrictedAndEvaluatedNutrientLow_DontShowFoodAsSuggestion()
        {
            Init();

            var result = (dietController.Evaluate(chocolateDietId) as PartialViewResult).Model as Diet;

            var lowNutrient = result.Summary.Single(x => x.NutrientName == "Vitamin B6");
            if (lowNutrient.Level != Level.Low)
                throw new Exception("Test assumptions failed! Please check low nutrients for this diet again.");
            lowNutrient.Suggestions.Should().NotContain("salmon");
        }

        private void AddCustomRestrictionsToDb()
        {
            var newRestrictions = new RestrictionUser
            {
                UserId = userId,
                Vegetarian = true,
            };
            context.RestrictionsUsers.Update(newRestrictions);
            context.SaveChanges();
        }

    }
}
