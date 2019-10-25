using System.Threading.Tasks;
using helpmeal.Services.MealService;
using helpmeal.Services.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;

        public MealController(IMealService mealService)
        {
            this.mealService = mealService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mealList = await mealService.FindMealsByUserAsync(User);
            return View(mealList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            return View();
        }
    }
}