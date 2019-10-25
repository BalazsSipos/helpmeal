﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FoodService.Services.BlobService;
using helpmeal.Models;
using helpmeal.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.MealService
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        IBlobStorageService blobStorageService;

        public MealService(ApplicationDbContext applicationDbContext, IMapper mapper, IBlobStorageService blobStorageService)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
            this.blobStorageService = blobStorageService;
        }

        public async Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user)
        {
            var mealList = await GetMealListByCycleDayAndUserDayAsync(cycleDay, user);
            var dailyMealViewModel = new DailyMealViewModel
            {
                Meals = mealList
            };
            return dailyMealViewModel;
        }

        public async Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(byte cycleDay, ClaimsPrincipal user)
        {
            var mealList = await applicationDbContext.Meals.Where(cd => cd.CycleDay.Equals(cycleDay)).Where(r => r.User.UserName == user.Identity.Name).Include(m => m.Recipe).ThenInclude(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).ThenInclude(i => i.Unit).ToListAsync();
            return mealList;
        }
    }
}