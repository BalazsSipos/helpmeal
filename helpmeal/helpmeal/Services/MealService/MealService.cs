using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;
using helpmeal.Services.MealService;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.MenuService
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext applicationDbContext;

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