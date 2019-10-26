using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models.Identity;
using helpmeal.Models.RequestModels.UserSettingsRequest;
using helpmeal.Models.ViewModels;
using helpmeal.Services.User;
using helpmeal.Services.UserSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class UserSettingsController : Controller
    {
        private readonly IUserSettingsService userSettingsService;
        
        public UserSettingsController(IUserSettingsService userSettingsService)
        {
           this.userSettingsService = userSettingsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            EditUserSettingsViewModel editUserSettingsViewModel = await userSettingsService.BuildUserSettingsViewModel(User);
            return View(editUserSettingsViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(EditUserSettingsRequest editUserSettingsRequest)
        {
            if (ModelState.IsValid)
            {
                await userSettingsService.EditSettings(User, editUserSettingsRequest);
            }
            return View(await userSettingsService.BuildUserSettingsViewModel(User));
        }

    }
}
