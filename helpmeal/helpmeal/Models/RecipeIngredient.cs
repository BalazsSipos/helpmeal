using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class RecipeIngredient
    {
        public long RecipeIngredientId { get; set; }
        public long RecipeId { get; set; }
        public long IngredientId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
    }
}
