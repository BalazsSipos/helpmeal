using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models.Identity;
using helpmeal.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class UserSettingsController : Controller
    {
        private new readonly AppUser User;
        private readonly byte numberOfWeeksInCycle;
        private readonly IUserService userService;
        public UserSettingsController(IUserService userService, long UserSettingId, AppUser User, byte numberOfWeeksInCycle)
        {
            this.User = User;
            this.numberOfWeeksInCycle = numberOfWeeksInCycle;
            this.userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserSettings()
        {
            string email = User.Identity.Email;
            byte numberOfWeeksInCycle = await UserService.
                timezoneService.GetTimezoneAsync(User.Identity.Name);
            return View();
        }
    }
}
