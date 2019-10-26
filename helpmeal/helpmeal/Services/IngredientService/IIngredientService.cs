using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.IngredientService
{
    public interface IIngredientService
    {
        void Addingredient(string ingredient_name, Unit ingredient_unit);
        List<Ingredient> FindAll();
    }
}
