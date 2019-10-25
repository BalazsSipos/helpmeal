using helpmeal.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class Meal
    {
        public long MealId { get; set; }
        public AppUser User { get; set; }
        public byte CycleDay { get; set; }
        public Recipe Recipe { get; set; }
        public int Amount { get; set; }
        public DateTime? SpecialDate { get; set; }
    }
}
