using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public IngredientService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Addingredient(string ingredient_name, Unit ingredient_unit)
        {
            Ingredient ingredient = new Ingredient()
            {
                Name = ingredient_name,
                Unit = ingredient_unit
            };
            applicationDbContext.Ingredients.Add(ingredient);
            applicationDbContext.SaveChanges();
        }

        public List<Ingredient> FindAll()
        {
            List<Ingredient> results = applicationDbContext.Ingredients.ToList();
            return results;
        }
    }
}
