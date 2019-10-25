using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public List<UserSetting> UserSettings { get; set; }
        public List<ShoppingDaysOfWeek> ShoppingDaysOfWeek { get; set; }
        public List<Meal> Meal { get; set; }
        public byte NumberOfWeeksInCycle { get; set; }
    }
}
