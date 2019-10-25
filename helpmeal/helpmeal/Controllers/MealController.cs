using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;
using helpmeal.Models.ViewModels.MealViewModels;
using helpmeal.Services.MealService;
using helpmeal.Services.MenuService;
using helpmeal.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;
        private readonly IUserService userService;

        public MealController(IMealService mealService, IUserService userService)
        {
            this.mealService = mealService;
            this.userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mealList = await mealService.FindMealsByUserAsync(User);
            var userSetting = await userService.GetUserSettingByUserAsync(User);
            return View(new WeeklySummaryViewModel
            {
                MealList = mealList,
                NumberOfDaysInCycle = userSetting.numberOfWeeksInCycle 
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            return View();
        }
    }
}