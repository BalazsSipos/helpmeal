using helpmeal.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Services.UserSettings
{
    public class UserSettings : IUserSettings
    {
        private readonly IUserSettings userService;
        private readonly UserManager<AppUser> userMgr;

        public async Task<byte> GetNumberOfWeeksInCycleAsync(string email)
        {
            var user = await userMgr.FindByEmailAsync(email);
            return user.NumberOfWeeksInCycle;
        }

        public async Task<List<byte>> GetDaysOfShoppingAsync(string email)
        {
            var user = await userMgr.FindByEmailAsync(email);
            var days = user.ShoppingDaysOfWeek;
            List<byte> daysOfShopping = new List<byte>();
            foreach (var day in days)
            {
                daysOfShopping.Add(day.DaysOfShopping);
            }
            return daysOfShopping;
        }

    }
}
