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

namespace DietAnalyzer.IntegrationTests.SingleDomain
{
    class RestrictionTests : IntegrationTests
    {
        private RestrictionController controller;
        private void Init()
        {
            controller = controllerFactory.GetRestrictionController();
        }

        [Test]
        public void Manage_RestrictionsInDb_GetRestrictions()
        {
            Init();
            AddCustomRestrictionsToDb();

            var result = controller.Manage() as ViewResult;

            var restrictionsReturnedToUser = (result.Model as RestrictionViewModel).RestrictionInfo;
            restrictionsReturnedToUser.DairyIntolerant.Should().BeTrue();
            restrictionsReturnedToUser.Paleo.Should().BeFalse();
        }

        [Test]
        public void ManagePost_RestrictionsModified_UpdateRestrictionsInDb()
        {
            Init();
            var restrictions = restrictionService.Get(userId);
            restrictions.Pescetarian = true;
            restrictions.HeartProblems = false;

            controller.Manage(new RestrictionViewModel() { RestrictionInfo = restrictions });

            var restrictionsInDb = context.RestrictionsUsers.Single(x => x.UserId == userId);
            restrictionsInDb.Pescetarian.Should().BeTrue();
            restrictionsInDb.HeartProblems.Should().BeFalse();
        }

        private void AddCustomRestrictionsToDb()
        {
            var newRestrictions = new RestrictionUser
            {
                UserId = userId,
                DairyIntolerant = true,
                Paleo = false,
            };
            context.RestrictionsUsers.Update(newRestrictions);
            context.SaveChanges();
        }

    }
}
