using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Models.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;

namespace DietAnalyzer.IntegrationTests.SingleDomain
{
    class DietTests : IntegrationTests
    {
        private DietController controller;
        private int initialDietsCount, initialItemsCount;
        private void Init()
        {
            controller = controllerFactory.GetDietController();
            initialDietsCount = context.Diets.Where(x => x.UserId == userId).Count();
            initialItemsCount = context.DietItems.Where(x => x.DietId == chocolateDietId).Count();
        }

        [Test]
        public void DietList_ExampleDietsInDb_GetDietList()
        {
            Init();

            var result = controller.DietList() as ViewResult;

            var dietsReturnedToUser = (result.Model as DietListViewModel).Diets;
            dietsReturnedToUser.Should().HaveCount(2);
            dietsReturnedToUser.Where(x => x.Name.Contains("chocolate")).Should().HaveCount(1);
        }

        [Test]
        public void ManageDiet_DietInDb_GetThisDiet()
        {
            Init();

            var result = controller.ManageDiet(chocolateDietId) as ViewResult;

            var dietReturnedToUser = (result.Model as DietViewModel).Diet;
            dietReturnedToUser.Should().NotBeNull();
            dietReturnedToUser.Name.Should().Contain("chocolate");
        }

        [Test]
        public void ManageDiet_DietNotInDb_GetNewDiet()
        {
            Init();

            var result = controller.ManageDiet(0) as ViewResult;

            var dietReturnedToUser = (result.Model as DietViewModel).Diet;
            dietReturnedToUser.Should().NotBeNull();
            dietReturnedToUser.Name.Should().BeEmpty();
        }

        [Test]
        public void ManageDietPost_DietItemDeleted_DecreaseDietItemCount()
        {
            Init();
            var viewModel = GetValidViewModel();
            viewModel.DietItems.RemoveAt(0);

            controller.ManageDiet(viewModel);

            var dietItemsInDb = context.DietItems.Where(x => x.DietId == chocolateDietId);
            dietItemsInDb.Count().Should().Be(initialItemsCount - 1);
        }

        [Test]
        public void ManageDietPost_DietItemAdded_IncreaseDietItemCount()
        {
            Init();
            var viewModel = GetValidViewModel();
            viewModel.DietItems.Add(new DietItem { FoodItemId = 1, MeasureId = 1, Quantity = 0.0F });

            controller.ManageDiet(viewModel);

            var dietItemsInDb = context.DietItems.Where(x => x.DietId == chocolateDietId);
            dietItemsInDb.Count().Should().Be(initialItemsCount + 1);
        }

        [Test]
        public void ManageDietPost_ExistingDietModified_ModifyDietInDb()
        {
            Init();
            var viewModel = GetValidViewModel();
            viewModel.Diet.Name = "abc";

            controller.ManageDiet(viewModel);

            var dietsInDb = context.Diets.Where(x => x.UserId == userId);
            dietsInDb.Where(x => x.Name.Contains("chocolate")).Should().HaveCount(0);
            dietsInDb.Where(x => x.Name == "abc").Should().HaveCount(1);
            dietsInDb.Should().HaveCount(initialDietsCount);
        }

        [Test]
        public void ManageDietPost_DietItemModified_ModifyDietItemInDb()
        {
            Init();
            var viewModel = GetValidViewModel();
            var itemToModify = viewModel.DietItems.Single(x => x.MeasureId == 12);
            var indexToModify = viewModel.DietItems.IndexOf(itemToModify);
            viewModel.DietItems[indexToModify] = new DietItem
            {
                DietId = itemToModify.DietId,
                FoodItemId = itemToModify.FoodItemId,
                Quantity = itemToModify.Quantity,
                MeasureId = 2, // measureId = 12 is slices (bread), measureId = 2 is tablespoons (universal)
            };
            /* Note: if I try to modify the itemToModify directly instead of creating a new one first,
               changes are written not only to viewModel.DietItems, but also to context.DietItems.
               This is consistent with how collections usually work in C#, but I was not expecting
               to see this behavior in a DbSet.
               If I modify the viewModel.Diet (as in the ExistingDietModified method above), I get 
               a behavior which is even weirder - the debugger shows context.Diets as modified again, 
               BUT the actual code executes as if context.Diets was not modified. (!) In the case of 
               viewModel.DietItems, however, both the debugger and the actual code see the modification.
               All of this happens only during tests, not during actual controller usage.

               I don't know what's going on. I can only guess that this is a yet another situation where
               Entity and Linq don't like each other, and one of them sabotages the work of the other.
               Perhaps the debugger somehow gets caught in the crossfire. 
               Or maybe there is something wrong with my test DB setup? Hopefully not, but at least the
               actual production code works anyway. This code works too (produces positives, but ALSO 
               negatives, if for example I comment out the controller action line), as long as you use 
               this slightly more verbose approach.

               Update: I checked the same thing for DietItemAdded and DietItemDeleted methods above.
               In both cases, the result is what I would expect from a DbSet - namely, modifying 
               the viewModel.DietItems collection does NOT modify context.DietItems. Definitely some 
               inconsistent behavior here...
            */

            controller.ManageDiet(viewModel);

            var dietItemsInDb = context.DietItems.Where(x => x.DietId == chocolateDietId);
            dietItemsInDb.Where(x => x.MeasureId == 12).Count().Should().Be(0);
            dietItemsInDb.Where(x => x.MeasureId == 2).Count().Should().Be(1);
            dietItemsInDb.Count().Should().Be(initialItemsCount);
        }

        private DietViewModel GetValidViewModel()
        {
            var chocolateDietId = context.Diets.Single(x => x.Name.Contains("chocolate")).Id;
            var viewModel = ((controller.ManageDiet(chocolateDietId) as ViewResult).Model as DietViewModel);
            foreach (var item in viewModel.DietItems) { item.Diet = null; item.Measure = null; }
            return viewModel;
        }

        [Test]
        public void ManageDietPost_NewDietAdded_AddDietToDb()
        {
            Init();
            var newViewModel = ((controller.ManageDiet(0) as ViewResult).Model as DietViewModel);
            newViewModel.Diet.Name = "abc";

            controller.ManageDiet(newViewModel);

            var dietsInDb = context.Diets.Where(x => x.UserId == userId);
            dietsInDb.Where(x => x.Name == "abc").Should().HaveCount(1);
            dietsInDb.Should().HaveCount(initialDietsCount + 1);
        }

        [Test]
        public void Delete_DietIdGiven_DeleteDietFromDb()
        {
            Init();

            controller.Delete(chocolateDietId);

            var foodsInDb = context.Diets.Where(x => x.UserId == userId);
            foodsInDb.Where(x => x.Name.Contains("chocolate")).Should().HaveCount(0);
            foodsInDb.Should().HaveCount(initialDietsCount - 1);
        }

        [Test]
        public void Delete_WrongIdGiven_DontDeleteAnythingFromDb()
        {
            Init();

            controller.Delete(-1);

            context.Diets.Where(x => x.UserId == userId).Count().Should().Be(initialDietsCount);
        }

        [Test]
        public void Evaluate_IdGiven_AddEvaluationResultsToDb()
        {
            Init();

            controller.Evaluate(chocolateDietId);

            var dietInDb = context.Diets.Single(x => x.Id == chocolateDietId);
            dietInDb.Nutritions.CaloriesPer100g.Should().NotBeNull();
            dietInDb.Summary.Should().NotBeEmpty();
        }


    }
}
