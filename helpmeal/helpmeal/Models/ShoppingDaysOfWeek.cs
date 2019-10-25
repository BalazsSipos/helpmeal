using helpmeal.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class ShoppingDaysOfWeek
    {
        public long ShoppingDaysOfWeekId { get; set; }
        public AppUser User { get; set; }
        public byte DaysOfShopping { get; set; }
    }
}
