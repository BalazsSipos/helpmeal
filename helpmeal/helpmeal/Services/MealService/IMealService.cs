using helpmeal.Models.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.MealService
{
    public interface IMealService
    {
        Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(byte cycleDay, ClaimsPrincipal user);
        Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user);
        Task<NextDaysMealViewModel> BuildNextDaysMealViewModel(byte today, ClaimsPrincipal user);
        Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user, Meal newMeal);
        Task AddMeal(byte cycleDay, ClaimsPrincipal user, Meal newMeal);
        Task<List<Meal>> FindMealsByUserAsync(ClaimsPrincipal user);
    }
}
