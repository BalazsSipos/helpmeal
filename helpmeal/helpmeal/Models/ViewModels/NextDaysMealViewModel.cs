using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models.ViewModels
{
    public class NextDaysMealViewModel
    {
        public List<Meal> TodayMeals { get; set; }
        public SortedList<int, List<Meal>> NextDaysMeals { get; set; }
        public Dictionary<Recipe, int> AggregatedRecipes { get; set; }
        public Dictionary<Ingredient, int> AggregatedIngredients { get; set; }
    }
}
