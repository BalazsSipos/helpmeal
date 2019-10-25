using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;
using helpmeal.Models.ViewModels.MealViewModels;
using helpmeal.Services.MealService;
using helpmeal.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;
        private readonly IUserService userService;

        public MealController(IMealService mealService, IUserService userService)
        {
            this.mealService = mealService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mealList = await mealService.FindMealsByUserAsync(User);
            var userSetting = await userService.GetUserSettingByUserAsync(User);
            return View(new WeeklySummaryViewModel
            {
                MealList = mealList,
                NumberOfDaysInCycle = userSetting.numberOfWeeksInCycle
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(byte id)
        {
            //byte cycleDay = 1;

            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(id, User, null);
            return View(dailyMealViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(byte id, Meal newMeal)
        {
            if (ModelState.IsValid)
            {
                await mealService.AddMeal(id, User, newMeal);
                newMeal = null;
            }
            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(id, User, newMeal);
            return View(dailyMealViewModel);
            //return RedirectToAction(nameof(MealController.Edit), "Meal", new { cycleDay = cycleDay });
        }
    }
}
