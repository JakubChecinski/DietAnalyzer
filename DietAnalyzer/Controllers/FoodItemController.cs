using DietAnalyzer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFoodItemService _service;
        public FoodItemController(ILogger<HomeController> logger, IFoodItemService service)
        {
            _logger = logger;
            _service = service;
        }


    }
}
