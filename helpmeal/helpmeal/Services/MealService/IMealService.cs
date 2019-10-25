using helpmeal.Models;
using helpmeal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Services.MealService
{
    public interface IMealService
    {
        Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(byte cycleDay, ClaimsPrincipal user);
        Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user);
    }
}
