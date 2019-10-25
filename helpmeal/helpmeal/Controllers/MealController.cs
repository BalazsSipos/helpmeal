using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Services.MealService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;

        public MealController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()// byte cycleDay)
        {
            byte cycleDay = 1;
            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(cycleDay, User);
            return View(dailyMealViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id)
        {
            byte cycleDay = 1;
            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(cycleDay, User);
            return View(dailyMealViewModel);
        }
    }
}
