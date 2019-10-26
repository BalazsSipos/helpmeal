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
using Microsoft.EntityFrameworkCore;

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
            var appUser = await userService.FindUserByNameOrEmailAsync(user.Identity.Name);
            var bytes = await GetDaysOfShoppingAsync(appUser);
            var editUserSettingsViewModel = new EditUserSettingsViewModel
            {
                EditUserSettingsRequest = new EditUserSettingsRequest
                {
                    NumberOfWeeksInCycle = await GetNumberOfWeeksInCycleAsync(user),
                    DaysOfShopping = bytes
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

        public async Task<List<bool>> GetDaysOfShoppingAsync(AppUser user)
        {
            //var days = user.ShoppingDaysOfWeek;
            var days = await applicationDbContext.ShoppingDaysOfWeeks.Where(s => s.User == user).ToListAsync();
            List<bool> daysOfShopping = new List<bool>();
            for (byte i = 0; i < 7; i++)
            {
                daysOfShopping.Add(false);
            }
            if (days.Count != 0)
            {
                foreach (var day in days)
                {
                    daysOfShopping[day.DaysOfShopping - 1] = true;
                }
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
            var daysOfShopping = await GetDaysOfShoppingAsync(appUser);
            //await applicationDbContext.SaveChangesAsync();
            //for (byte i = 0; i < editUserSettingsRequest.DaysOfShopping.Count(); i++)
            for (byte i = 1; i <= 7; i++)
            {
                if (editUserSettingsRequest.DaysOfShopping[i-1])
                {
                    var day = await applicationDbContext.ShoppingDaysOfWeeks.FirstOrDefaultAsync(s => s.DaysOfShopping == i && s.User == appUser);
                    if(day == null)
                    {
                        ShoppingDaysOfWeek shoppingDaysOfWeek = new ShoppingDaysOfWeek()
                        {
                            DaysOfShopping = (i),
                            User = appUser
                        };
                        applicationDbContext.ShoppingDaysOfWeeks.Add(shoppingDaysOfWeek);
                    }
                } else
                {
                    if(daysOfShopping.Count != 0)
                    {
                        if(daysOfShopping[i-1])
                        {
                            var day = await applicationDbContext.ShoppingDaysOfWeeks.FirstOrDefaultAsync(s => s.DaysOfShopping == i && s.User == appUser);
                            if(day != null)
                            {
                                applicationDbContext.ShoppingDaysOfWeeks.Remove(day);
                                await applicationDbContext.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            await applicationDbContext.SaveChangesAsync();
        }
    }
}