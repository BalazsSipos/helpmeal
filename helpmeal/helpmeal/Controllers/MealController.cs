<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models;
using helpmeal.Services.MealService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

=======
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;
using helpmeal.Models.ViewModels.MealViewModels;
using helpmeal.Services.MealService;
using helpmeal.Services.MenuService;
using helpmeal.Services.User;
using Microsoft.AspNetCore.Mvc;

>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc
namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;
<<<<<<< HEAD

        public MealController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Add(byte cycleDay)
        //{
        //    //byte cycleDay = 1;
        //    var dailyMealViewModel = await mealService.BuildDailyMealViewModel(cycleDay, User);
        //    return View(dailyMealViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(byte cycleDay, Meal newMeal)
        //{
        //    //byte cycleDay = 1;
        //    //var dailyMealViewModel = await mealService.BuildDailyMealViewModel(cycleDay, User);
        //    //return RedirectToAction(nameof(MealController.Edit), "Meal", new { cycleDay = cycleDay } );
        //    //return View(dailyMealViewModel);
        //}

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
=======
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
        public async Task<IActionResult> Edit(long id)
        {
            return View();
        }
    }
}
>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc
