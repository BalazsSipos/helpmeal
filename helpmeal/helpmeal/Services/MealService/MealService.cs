using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FoodService.Services.BlobService;
using helpmeal.Models;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.MealService
{
    public class MealService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMealService mealService;
        private readonly IMapper mapper;
        IBlobStorageService blobStorageService;

        public MealService(ApplicationDbContext applicationDbContext, IMapper mapper, IBlobStorageService blobStorageService, IMealService mealService)
        {
            this.applicationDbContext = applicationDbContext;
            this.mealService = mealService;
            this.mapper = mapper;
            this.blobStorageService = blobStorageService;
        }

        public async Task<List<Meal>> GetMealListByCycleAndUserDayAsync(Meal meal, ClaimsPrincipal user)
        {
            var mealList = await applicationDbContext.Meals.Where(cd => cd.CycleDay.Equals(meal.CycleDay)).Where(r => r.User.UserName == user.Identity.Name).ToListAsync();
            return mealList;
        }


    }
}
