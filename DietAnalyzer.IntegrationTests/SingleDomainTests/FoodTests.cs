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

namespace DietAnalyzer.IntegrationTests.SingleDomain
{
    class FoodTests : IntegrationTests
    {
        private FoodItemController controller;
        private int initialFoodsCount;
        private void Init()
        {
            controller = controllerFactory.GetFoodController();
            initialFoodsCount = context.FoodItems.Where(x => x.UserId == userId).Count();
        }


        [Test]
        public void FoodList_ExampleFoodsInDb_GetFoodList()
        {
            Init();

            var result = controller.FoodList() as ViewResult;

            var foodsReturnedToUser = (result.Model as FoodListViewModel).Foods;
            foodsReturnedToUser.Should().HaveCount(2);
            foodsReturnedToUser.Where(x => x.Name == "carrots").Should().HaveCount(1);
        }

        [Test]
        public void ManageFood_FoodInDb_GetThisFood()
        {
            Init();

            var result = controller.ManageFood(carrotId) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Should().NotBeNull();
            foodReturnedToUser.Name.Should().Be("carrots");
        }

        [Test]
        public void ManageFood_FoodNotInDb_GetNewFood()
        {
            Init();

            var result = controller.ManageFood(0) as ViewResult;

            var foodReturnedToUser = (result.Model as FoodItemViewModel).FoodItem;
            foodReturnedToUser.Should().NotBeNull();
            foodReturnedToUser.Name.Should().BeEmpty();
        }

        [Test]
        public void ManageFoodPost_ExistingFoodModified_UpdateFoodInDb()
        {
            Init();
            var viewModel = ((controller.ManageFood(carrotId) as ViewResult).Model as FoodItemViewModel);
            viewModel.FoodItem.Name = "abc";

            controller.ManageFood(viewModel);

            var foodsInDb = context.FoodItems.Where(x => x.UserId == userId);
            foodsInDb.Where(x => x.Name == "carrots").Should().HaveCount(0);
            foodsInDb.Where(x => x.Name == "abc").Should().HaveCount(1);
            foodsInDb.Should().HaveCount(initialFoodsCount);
        }

        [Test]
        public void ManageFoodPost_NewFoodAdded_AddFoodToDb()
        {
            Init();
            var viewModel = ((controller.ManageFood(0) as ViewResult).Model as FoodItemViewModel);
            viewModel.FoodItem.Name = "abc";

            controller.ManageFood(viewModel);

            var foodsInDb = context.FoodItems.Where(x => x.UserId == userId);
            foodsInDb.Where(x => x.Name == "abc").Should().HaveCount(1);
            foodsInDb.Should().HaveCount(initialFoodsCount + 1);
        }

        [Test]
        public void Delete_FoodIdGiven_DeleteFoodFromDb()
        {
            Init();

            controller.Delete(carrotId);

            var foodsInDb = context.FoodItems.Where(x => x.UserId == userId);
            foodsInDb.Where(x => x.Name == "carrots").Should().HaveCount(0);
            foodsInDb.Should().HaveCount(initialFoodsCount - 1);
        }

        [Test]
        public void Delete_WrongIdGiven_DontDeleteAnythingFromDb()
        {
            Init();

            controller.Delete(-1);

            context.FoodItems.Where(x => x.UserId == userId).Count().Should().Be(initialFoodsCount);
        }


    }
}
