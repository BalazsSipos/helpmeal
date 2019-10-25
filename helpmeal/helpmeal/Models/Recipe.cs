using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class Recipe
    {
        public long RecipeId { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
