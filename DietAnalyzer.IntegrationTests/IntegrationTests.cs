using DietAnalyzer.Data;
using DietAnalyzer.Models.Domains;
using DietAnalyzer.Services;
using DietAnalyzer.Services.Utilities;
using DietAnalyzer.UnitTests.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace DietAnalyzer.IntegrationTests
{
    abstract class IntegrationTests
    {
        private DbContextOptions<ApplicationDbContext> dbStructureInfo;
        protected DietService dietService;
        protected FoodItemService foodService;
        protected RestrictionService restrictionService;
        protected EvaluationService evaluationService;
        protected MeasureService measureService;
        protected ApplicationDbContext context;
        protected UnitOfWork unitOfWork;
        protected ControllerFactory controllerFactory;
        protected string userName, userId;
        protected int carrotId, orangeJuiceId, chocolateDietId, medDietId;

        [SetUp]
        protected void InitDb()
        {
            // create database
            dbStructureInfo = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(local)\\SQLEXPRESS;Database=DietAnalyzerTests;User Id=JCH;Password=pwd")
                .Options;
            context = new ApplicationDbContext(dbStructureInfo);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
            // add test data
            userName = "userName";
            userId = AddUserToDb();
            InitializeServices();
            AddCustomDataToDb();
            context.SaveChanges();
            // prepare objects for child classes
            GetExampleObjectIds();
            controllerFactory = new ControllerFactory(dietService, foodService, measureService,
                restrictionService, evaluationService, userName, userId);
        }

        [TearDown]
        protected void DisposeDb()
        {
            context.Dispose();
        }

        private string AddUserToDb()
        {
            if (context.Users.Any()) return null;
            context.Users.Add(new ApplicationUser
            {
                UserName = userName
            });
            context.SaveChanges();
            return context.Users.First().Id;
        }

        private void InitializeServices()
        {
            unitOfWork = new UnitOfWork(context);
            restrictionService = new RestrictionService(unitOfWork);
            measureService = new MeasureService(unitOfWork);
            foodService = new FoodItemService(unitOfWork, measureService, restrictionService);
            dietService = new DietService(unitOfWork, foodService);
            evaluationService = new EvaluationService(foodService);
        }

        private void AddCustomDataToDb()
        {
            var solutionDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            var mockLogger = new CustomMockLogger<ExampleDataService>();
            var mockWebHost = new Mock<IWebHostEnvironment>();
            mockWebHost.Setup(x => x.WebRootPath).Returns(solutionDirectory + "\\DietAnalyzer\\wwwroot\\");
            var customDataService = new ExampleDataService(unitOfWork, dietService, foodService, measureService,
                mockWebHost.Object, mockLogger);
            customDataService.InsertExampleData(userId);
        }

        private void GetExampleObjectIds()
        {
            orangeJuiceId = context.FoodItems.Single(x => x.Name == "orange juice").Id;
            carrotId = context.FoodItems.Single(x => x.Name == "carrots").Id;
            medDietId = context.Diets.Single(x => x.Name.Contains("Mediterranean")).Id;
            chocolateDietId = context.Diets.Single(x => x.Name.Contains("chocolate")).Id;
        }

    }
}
