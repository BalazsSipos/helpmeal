using System.Collections.Generic;
using helpmeal.Models.Identity;

namespace helpmeal.Models.ViewModels.MealViewModels
{
    public class WeeklySummaryViewModel
    {
        public List<Meal> MealList { get; set; }
        public byte NumberOfDaysInCycle { get; set; }
    }
}