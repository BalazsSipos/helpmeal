using AutoMapper;
using helpmeal.Models;
using helpmeal.Models.Identity;
using helpmeal.Models.RequestModels.UserSettingsRequest;
using helpmeal.Models.ViewModels;
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
                    NumberOfWeeksInCycle = await GetNumberOfWeeksInCycleAsync(user),
                    
                    //DaysOfShopping = await GetDaysOfShoppingAsync(user)
                }
            };
            return editUserSettingsViewModel;
        }

        public async Task<byte> GetNumberOfWeeksInCycleAsync(ClaimsPrincipal user)
        {
            var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
            return appUser.NumberOfWeeksInCycle;
        }

        public async Task<List<byte>> GetDaysOfShoppingAsync(ClaimsPrincipal user)
        {
            var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
            List<byte> daysOfShopping = new List<byte> { };
            if (appUser.ShoppingDaysOfWeek == null)
            {
                daysOfShopping.Add(1);
                return daysOfShopping;
            }
            var days = appUser.ShoppingDaysOfWeek.ToList();
            foreach (var day in days)
            {
                daysOfShopping.Add(day.DaysOfShopping);
            }
            return daysOfShopping;
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

            public async Task<UserSettingsService> SetUserSettingsAsync(string email, List<bool> DaysOfShopping, byte NumberOfWeeksInCycle)
        {
            var user = await userMgr.FindByEmailAsync(email);
            EditUserSettingsRequest userSettingsReq = new EditUserSettingsRequest();
            userSettingsReq.DaysOfShopping = DaysOfShopping;
            userSettingsReq.NumberOfWeeksInCycle = NumberOfWeeksInCycle;

            var userSettings = mapper.Map<EditUserSettingsRequest, UserSettingsService>(userSettingsReq);
            await applicationDbContext.AddAsync(userSettingsReq);
            return userSettings;
        }

        public async Task EditSettingsAsync(ClaimsPrincipal user, EditUserSettingsRequest editUserSettingsRequest)
        {
            var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
            appUser.NumberOfWeeksInCycle = editUserSettingsRequest.NumberOfWeeksInCycle;
            await applicationDbContext.SaveChangesAsync();
            for (int i = 0; i < editUserSettingsRequest.DaysOfShopping.Count(); i++)
            {
                if (editUserSettingsRequest.DaysOfShopping[i] == true)
                {
                    ShoppingDaysOfWeek shoppingDaysOfWeek = new ShoppingDaysOfWeek() { DaysOfShopping = (byte)(i + 1), User = appUser };
                    applicationDbContext.ShoppingDaysOfWeeks.Add(shoppingDaysOfWeek);
                    await applicationDbContext.SaveChangesAsync();
                }
            }
        }
    }
}