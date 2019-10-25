using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.MenuService
{
    public interface IMenuService
    {
        Task<List<Meal>> FindMealsByUserAsync(ClaimsPrincipal user);
    }
}