using helpmeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Services.MealService
{
    public interface IMealService
    {
        Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(Meal meal, ClaimsPrincipal user);
    }
}
