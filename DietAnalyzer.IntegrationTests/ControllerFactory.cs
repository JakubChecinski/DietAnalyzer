using System;
using System.Collections.Generic;
using DietAnalyzer.Controllers;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
using DietAnalyzer.UnitTests.Extensions;

namespace DietAnalyzer.IntegrationTests
{
    public class ControllerFactory
    {
        private string userName, userId;
        private DietService dietService;
        private FoodItemService foodService;
        private MeasureService measureService;
        private RestrictionService restrictionService;
        private EvaluationService evaluationService;
        public ControllerFactory(DietService dietService, FoodItemService foodService,
            MeasureService measureService, RestrictionService restrictionService, 
            EvaluationService evaluationService, string userName, string userId)
        {
            this.dietService = dietService;
            this.foodService = foodService;
            this.measureService = measureService;
            this.restrictionService = restrictionService;
            this.evaluationService = evaluationService;
            this.userName = userName;
            this.userId = userId;
        }

        public DietController GetDietController()
        {
            var mockLogger = new CustomMockLogger<DietController>();
            var controller = new DietController(mockLogger, dietService, foodService, evaluationService);
            controller.MockCurrentUser(userId, userName);
            controller.MockUrlAction("testUrl");
            return controller;
        }

        public FoodItemController GetFoodController()
        {
            // note: image processing is not covered in the tests here
            // therefore, the image helper object is only a dummy and will never be used 
            // but it must be provided to make the compiler happy
            ImageHelper imageHelper = null;
            var mockLogger = new CustomMockLogger<FoodItemController>();
            var controller = new FoodItemController(mockLogger, foodService, measureService, imageHelper);
            controller.MockCurrentUser(userId, userName);
            controller.MockUrlAction("testUrl");
            return controller;
        }

        public MeasureController GetMeasureController()
        {
            var mockLogger = new CustomMockLogger<MeasureController>();
            var controller = new MeasureController(mockLogger, measureService);
            controller.MockCurrentUser(userId, userName);
            return controller;
        }

        public RestrictionController GetRestrictionController()
        {
            var mockLogger = new CustomMockLogger<RestrictionController>();
            var controller = new RestrictionController(mockLogger, restrictionService);
            controller.MockCurrentUser(userId, userName);
            return controller;
        }

    }
}
