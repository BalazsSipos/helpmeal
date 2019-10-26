using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;
using FoodService.Services.BlobService;
using helpmeal.Models;
using helpmeal.Models.ViewModels;
using helpmeal.Services.RecipeService;
using helpmeal.Services.User;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.MealService
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext applicationDbContext;
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

        public async Task<NextDaysMealViewModel> BuildNextDaysMealViewModel(byte today, ClaimsPrincipal user)
        {
            var todayMealList = await GetMealListByCycleDayAndUserDayAsync(today, user);
            SortedList<int, List<Meal>> nextDaysMenus = new SortedList<int, List<Meal>>();
            for (byte i = 1; i <= 7; i++)
            {
                var weeklyMealViewModel = await BuildDailyMealViewModel((byte)(today + i), user);
                nextDaysMenus.Add(i, weeklyMealViewModel.Meals);
            }

            List<Meal> nextThreeDayMeals = new List<Meal>();
            for (byte i = 1; i <= 3; i++)
            {
                nextThreeDayMeals.AddRange(await GetMealListByCycleDayAndUserDayAsync((byte)(today + i), user));
            }

            Dictionary<Recipe, int> aggregatedRecipes = new Dictionary<Recipe, int>();
            Dictionary<Ingredient, int> aggregatedIngredients = new Dictionary<Ingredient, int>();

            for (int mealInd = 0; mealInd < nextThreeDayMeals.Count; mealInd++)
            {
                if (aggregatedRecipes.ContainsKey(nextThreeDayMeals[mealInd].Recipe))
                {
                    aggregatedRecipes[nextThreeDayMeals[mealInd].Recipe] += nextThreeDayMeals[mealInd].Amount;
                }
                else
                {
                    aggregatedRecipes.Add(nextThreeDayMeals[mealInd].Recipe, nextThreeDayMeals[mealInd].Amount);
                }

                for (int ingredientsIndex = 0; ingredientsIndex < nextThreeDayMeals[mealInd].Recipe.RecipeIngredients.Count; ingredientsIndex++)
                {
                    if (aggregatedIngredients.ContainsKey(nextThreeDayMeals[mealInd].Recipe.RecipeIngredients[ingredientsIndex].Ingredient))
                    {
                        aggregatedIngredients[nextThreeDayMeals[mealInd].Recipe.RecipeIngredients[ingredientsIndex].Ingredient] += nextThreeDayMeals[mealInd].Amount * nextThreeDayMeals[mealInd].Recipe.RecipeIngredients[ingredientsIndex].Amount;
                    }
                    else
                    {
                        aggregatedIngredients.Add(nextThreeDayMeals[mealInd].Recipe.RecipeIngredients[ingredientsIndex].Ingredient, nextThreeDayMeals[mealInd].Amount * nextThreeDayMeals[mealInd].Recipe.RecipeIngredients[ingredientsIndex].Amount);
                    }
                }
            }

            /*@meal.Amount x @meal.Recipe.Name
   @foreach(var ingredients in meal.Recipe.RecipeIngredients)
    var amountTotal = meal.Amount * ingredients.Amount;
    @amountTotal<span> & nbsp; &nbsp;</ span > @ingredients.Ingredient.Unit.Name<span> & nbsp; &nbsp;</ span > @ingredients.Ingredient.Name < br />*/

            var nextDaysMealViewModel = new NextDaysMealViewModel
            {
                TodayMeals = todayMealList,
                NextDaysMeals = nextDaysMenus,
                AggregatedRecipes = aggregatedRecipes,
                AggregatedIngredients = aggregatedIngredients
            };
            return nextDaysMealViewModel;
        }

        public async Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(byte cycleDay, ClaimsPrincipal user)
        {
            var mealList = await applicationDbContext.Meals.Where(cd => cd.CycleDay.Equals(cycleDay)).Where(r => r.User.UserName == user.Identity.Name).Include(m => m.Recipe).ThenInclude(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).ThenInclude(i => i.Unit).ToListAsync();
            return mealList;
        }
        public async Task AddMeal(byte cycleDay, ClaimsPrincipal user, Meal newMeal)
        {
            if (newMeal != null)
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

        public async Task<List<Meal>> FindMealsByUserAsync(ClaimsPrincipal user)
        {
            var mealList = await applicationDbContext.Meals.Include(m => m.Recipe).Where(m => m.User.Email.Equals(user.Identity.Name)).OrderBy(m => m.CycleDay).ToListAsync();
            return mealList;
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
    }
}
