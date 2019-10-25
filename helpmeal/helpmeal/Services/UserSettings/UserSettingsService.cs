using AutoMapper;
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
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IUserSettings userService;
        private readonly UserManager<AppUser> userMgr;
        private readonly IMapper mapper;

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

        public async Task<byte> SetNumberOfWeeksInCycleAsync(string email, byte weeks)
        {
            var user = await userMgr.FindByEmailAsync(email);
            
            await applicationDbContext.ShoppingDaysOfWeeks.AddAsync(weeks)
            return weeks;
        }
    }
}



public async Task<Restaurant> SaveRestaurantAsync(RestaurantRequest restaurantReq, string managerName)
{
    var manager = await userService.FindUserByNameOrEmailAsync(managerName);
    var restaurant = mapper.Map<RestaurantRequest, Restaurant>(restaurantReq);
    restaurant.Manager = manager;
    await applicationDbContext.Restaurants.AddAsync(restaurant);
    await applicationDbContext.SaveChangesAsync();
    return restaurant;
}