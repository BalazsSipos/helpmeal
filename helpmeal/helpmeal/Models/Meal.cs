using helpmeal.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class Meal
    {
        public long MealId { get; set; }
        public AppUser User { get; set; }
        public byte CycleDay { get; set; }
        public Recipe Recipe { get; set; }
        [Required]
        public int Amount { get; set; }
        public DateTime? SpecialDate { get; set; }
    }
}
