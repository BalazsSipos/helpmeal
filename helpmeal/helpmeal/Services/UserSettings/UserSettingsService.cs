using AutoMapper;
using helpmeal.Models.Identity;
using helpmeal.Models.RequestModels.UserSettingsRequest;
using helpmeal.Models.ViewModel;
using helpmeal.Services.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Services.UserSettings
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<AppUser> userMgr;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserSettingsService(ApplicationDbContext applicationDbContext, UserManager<AppUser> userMgr, IMapper mapper, IUserService userService)
        {
            this.applicationDbContext = applicationDbContext;
            this.userMgr = userMgr;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task<EditUserSettingsViewModel> BuildUserSettingsViewModel(ClaimsPrincipal user)
        {
            var editUserSettingsViewModel = new EditUserSettingsViewModel
            {
                EditUserSettingsRequest = new EditUserSettingsRequest
                {
                    NumberOfWeeksInCycle = await GetNumberOfWeeksInCycleAsync(user)
                }
            };
            return editUserSettingsViewModel;
        }

        public async Task<byte> GetNumberOfWeeksInCycleAsync(ClaimsPrincipal user)
        {
            var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
            return appUser.NumberOfWeeksInCycle;
        }

        public List<byte> GetDaysOfShoppingAsync(AppUser user)
        {
            var days = user.ShoppingDaysOfWeek;
            List<byte> daysOfShopping = new List<byte>();
            foreach (var day in days)
            {
                daysOfShopping.Add(day.DaysOfShopping);
            }
            return daysOfShopping;
        }

        public async Task<UserSettingsService> SetUserSettingsAsync(string email, List<byte> DaysOfShopping, byte NumberOfWeeksInCycle)
        {
            var user = await userMgr.FindByEmailAsync(email);
            EditUserSettingsRequest userSettingsReq = new EditUserSettingsRequest();
            userSettingsReq.DaysOfShopping = DaysOfShopping;
            userSettingsReq.NumberOfWeeksInCycle = NumberOfWeeksInCycle;

            var userSettings = mapper.Map<EditUserSettingsRequest, UserSettingsService>(userSettingsReq);
            await applicationDbContext.AddAsync(userSettingsReq);
            return userSettings;
        }

        public async Task EditSettings(ClaimsPrincipal user, EditUserSettingsRequest editUserSettingsRequest)
        {
            var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
            appUser.NumberOfWeeksInCycle = editUserSettingsRequest.NumberOfWeeksInCycle;
            await applicationDbContext.SaveChangesAsync();
        }
    }
}