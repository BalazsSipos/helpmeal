using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class Ingredient
    {
        public long IngredientId { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
    }
}
