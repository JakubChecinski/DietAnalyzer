using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;

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
