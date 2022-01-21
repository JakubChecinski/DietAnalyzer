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
    class MeasureTests : IntegrationTests
    {
        private MeasureController controller;
        private List<Measure> measures;
        private void Init()
        {
            controller = controllerFactory.GetMeasureController();
            controller.MockCurrentUser(userId, userName);
            measures = measureService.GetCustom(userId).ToList();
        }


        [Test]
        public void Manage_ExampleMeasuresInDb_GetMeasures()
        {
            Init();

            var result = controller.Manage() as ViewResult;

            var measuresReturnedToUser = (result.Model as MeasureViewModel).Measures;
            measuresReturnedToUser.Should().HaveCount(2);
            measuresReturnedToUser.Where(x => x.Name == "liters").Should().HaveCount(1);
        }

        [Test]
        public void ManagePost_MeasureModified_UpdateMeasureInDb()
        {
            Init();
            var measureToModify = measures.Where(x => x.Name == "liters").First();
            measureToModify.Name = "abc";

            controller.Manage(new MeasureViewModel() { Measures = measures });

            var measuresInDb = context.Measures.Where(x => x.UserId == userId);
            measuresInDb.Where(x => x.Name == "liters").Should().HaveCount(0);
            measuresInDb.Where(x => x.Name == "abc").Should().HaveCount(1);
        }

        [Test]
        public void ManagePost_MeasureDeleted_DeleteMeasureFromDb()
        {
            Init();
            var initialMeasuresCount = measures.Count;
            var measureToDelete = measures.Where(x => x.Name == "liters").First();
            measures.Remove(measureToDelete);

            controller.Manage(new MeasureViewModel() { Measures = measures });

            var measuresInDb = context.Measures.Where(x => x.UserId == userId);
            measuresInDb.Where(x => x.Name == "liters").Should().HaveCount(0);
            measuresInDb.Should().HaveCount(initialMeasuresCount - 1);
        }

        [Test]
        public void ManagePost_MeasureAdded_AddMeasureToDb()
        {
            Init();
            var initialMeasuresCount = measures.Count;
            var measureToAdd = new Measure { Name = "abc" };
            measures.Add(measureToAdd);

            controller.Manage(new MeasureViewModel() { Measures = measures });

            var measuresInDb = context.Measures.Where(x => x.UserId == userId);
            measuresInDb.Where(x => x.Name == "abc").Should().HaveCount(1);
            measuresInDb.Should().HaveCount(initialMeasuresCount + 1);
        }


    }
}
