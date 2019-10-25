using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models.ViewModels
{
    public class DailyMealViewModel
    {
        public List<Meal> Meals { get; set; }
        public Meal NewMeal { get; set; }
        public DateTime DateTime { get; set; }
    }
}
