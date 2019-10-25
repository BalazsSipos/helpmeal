<<<<<<< HEAD
﻿using System;
=======
>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
<<<<<<< HEAD
using AutoMapper;
using FoodService.Services.BlobService;
using helpmeal.Models;
using helpmeal.Models.ViewModels;
using helpmeal.Services.RecipeService;
using helpmeal.Services.User;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.MealService
=======
using helpmeal.Models;
using helpmeal.Services.MealService;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.MenuService
>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext applicationDbContext;
<<<<<<< HEAD
        private readonly IRecipeService recipeService;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        IBlobStorageService blobStorageService;

        public MealService(ApplicationDbContext applicationDbContext, IRecipeService recipeService, IUserService userService, IMapper mapper, IBlobStorageService blobStorageService)
        {
            this.applicationDbContext = applicationDbContext;
            this.recipeService = recipeService;
            this.userService = userService;
            this.mapper = mapper;
            this.blobStorageService = blobStorageService;
        }



        //public async Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user)
        //{
        //    BuildDailyMealViewModel(cycleDay, user, null);
        //    var mealList = await GetMealListByCycleDayAndUserDayAsync(cycleDay, user);
        //    var recipeList = recipeService.GetAllRecipe();
        //    var dailyMealViewModel = new DailyMealViewModel
        //    {
        //        Meals = mealList,
        //        Recipes = recipeList,
        //        cycleDay = cycleDay
        //    };
        //    return dailyMealViewModel;
        //}

        public async Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user, Meal newMeal = null)
        {
            var mealList = await GetMealListByCycleDayAndUserDayAsync(cycleDay, user);
            var recipeList = await recipeService.GetAllRecipe();
            var dailyMealViewModel = new DailyMealViewModel
            {
                Meals = mealList,
                Recipes = recipeList,
                cycleDay = cycleDay,
                NewMeal = newMeal
            };
            return dailyMealViewModel;
        }

        public async Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(byte cycleDay, ClaimsPrincipal user)
        {
            var mealList = await applicationDbContext.Meals.Where(cd => cd.CycleDay.Equals(cycleDay)).Where(r => r.User.UserName == user.Identity.Name).ToListAsync();
            return mealList;
        }

        public async Task AddMeal(byte cycleDay, ClaimsPrincipal user, Meal newMeal)
        {
            if(newMeal != null)
            {
                var recipe = await recipeService.GetRecipeByIdAsync(newMeal.Recipe.RecipeId);
                newMeal.Recipe = recipe;
                newMeal.CycleDay = cycleDay;
                var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
                newMeal.User = appUser;
                await applicationDbContext.Meals.AddAsync(newMeal);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
=======

        public MealService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        
        public async Task<List<Meal>> FindMealsByUserAsync(ClaimsPrincipal user)
        {
            var mealList = await applicationDbContext.Meals.Include(m => m.Recipe).Where(m => m.User.Email.Equals(user.Identity.Name)).OrderBy(m => m.CycleDay).ToListAsync();
            return mealList;
        }
    }
}
>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc
