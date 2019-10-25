using System.Threading.Tasks;
using helpmeal.Services.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMenuService menuService;

        public MealController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mealList = await menuService.FindMealsByUserAsync(User);
            return View(mealList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            return View();
        }
    }
}