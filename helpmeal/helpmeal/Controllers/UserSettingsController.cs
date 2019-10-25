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
        private new readonly AppUser User;
        private readonly byte numberOfWeeksInCycle;
        private readonly IUserSettingsService userSettingsService;
        
        public UserSettingsController(IUserSettingsService userSettingsService, long UserSettingId, AppUser User, byte numberOfWeeksInCycle)
        {
            this.User = User;
            this.numberOfWeeksInCycle = numberOfWeeksInCycle;
            this.userSettingsService = userSettingsService;
        }

        [Authorize]
        [HttpGet("/UserSettings")]
        public async Task<IActionResult> UserSettings(string email, EditUserSettingsViewModel editUserSettingsViewModel)
        {
            return View(editUserSettingsViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserSettingsViewModel editUserSettingsViewModel, string email)
        {
            var daysOfShopping = await userSettingsService.GetDaysOfShoppingAsync(email);
            var numberOfWeeksInCycle = await userSettingsService.GetNumberOfWeeksInCycleAsync(email);

            //await UserSettingsService.SetUserSettingsAsync(User.Email, daysOfShopping, numberOfWeeksInCycle);

            return View(editUserSettingsViewModel);
        }

    }
}
