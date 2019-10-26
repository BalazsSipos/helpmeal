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
            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(id, User, null);
            return View(dailyMealViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(byte id, Meal newMeal)
        {
            if (ModelState.IsValid)
            {
                await mealService.AddMeal(id, User, newMeal);
                return RedirectToAction(nameof(MealController.Edit), "Meal");
            }
            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(id, User, newMeal);
            return View(dailyMealViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditMeal(long id, Meal meal)
        {
            if (ModelState.IsValid)
            {
                var updatedMeal = await mealService.EditMeal(id, meal.Amount);
                return RedirectToAction(nameof(MealController.Edit), "Meal", new { id = updatedMeal.CycleDay });
            }
            var existingMeal = await mealService.GetMealById(id);
            //var dailyMealViewModel = await mealService.BuildDailyMealViewModel((byte) id, User, null);
            return RedirectToAction(nameof(MealController.Edit), "Meal", new { id = existingMeal.CycleDay });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            byte cycleDay = await mealService.DeleteMeal(id);

            var dailyMealViewModel = await mealService.BuildDailyMealViewModel(cycleDay, User, null);
            return RedirectToAction(nameof(MealController.Edit), "Meal", new { id = cycleDay });
        }
    }
}
