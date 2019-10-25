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
            byte today = 1;
            var nextDaysMealViewModel = await mealService.BuildNextDaysMealViewModel(today, User);
            return View(nextDaysMealViewModel);
        }
    }
}
