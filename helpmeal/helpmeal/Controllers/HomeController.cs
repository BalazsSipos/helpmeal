using helpmeal.Services.MealService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMealService mealService;

        public HomeController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
            byte cycleDay = 1;
            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(cycleDay, User);
            return View(dailyMealViewModel);
        }
    }
}
