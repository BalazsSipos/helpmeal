using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;
using helpmeal.Models.ViewModels.MealViewModels;
using helpmeal.Services.MealService;
using helpmeal.Services.User;
using helpmeal.Services.UserSettings;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;
        private readonly IUserSettingsService userSettingsService;

        public MealController(IMealService mealService, IUserSettingsService userSettingsService)
        {
            this.mealService = mealService;
            this.userSettingsService = userSettingsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mealList = await mealService.FindMealsByUserAsync(User);
            return View(new WeeklySummaryViewModel
            {
                MealList = mealList,
                NumberOfDaysInCycle = await userSettingsService.GetNumberOfWeeksInCycleAsync(User)
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
