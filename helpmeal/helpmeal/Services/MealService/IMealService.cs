using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.MealService
{
    public interface IMealService
    {
        Task<List<Meal>> FindMealsByUserAsync(ClaimsPrincipal user);
    }
}