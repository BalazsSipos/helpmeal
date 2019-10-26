using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models.Identity;
using helpmeal.Models.ViewModel;
using helpmeal.Services.User;
using helpmeal.Services.UserSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class UserSettingsController : Controller
    {
        private readonly byte numberOfWeeksInCycle;
        private readonly IUserSettingsService userSettingsService;
        
        public UserSettingsController(IUserSettingsService userSettingsService)
        {
           this.userSettingsService = userSettingsService;
        }

        [Authorize]
        [HttpGet("/UserSettings")]
        public async Task<IActionResult> UserSettings()
        {
            EditUserSettingsViewModel editUserSettingsViewModel = await userSettingsService.BuildUserSettingsViewModel(User);
            //editUserSettingsViewModel.EditUserSettingsRequest.DaysOfShopping = userSettingsService.GetDaysOfShoppingAsync(user);
            return View(editUserSettingsViewModel);
        }

        /*[Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserSettingsViewModel editUserSettingsViewModel, AppUser user)
        {
            var daysOfShopping = await userSettingsService.GetDaysOfShoppingAsync(user);
            var numberOfWeeksInCycle = await userSettingsService.GetNumberOfWeeksInCycleAsync(user);

            //await UserSettingsService.SetUserSettingsAsync(User.Email, daysOfShopping, numberOfWeeksInCycle);

            return View(editUserSettingsViewModel);
        }*/

    }
}
