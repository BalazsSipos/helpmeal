using helpmeal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal
{
    public class ApplicationDbInitializer
    {
        public static void SeedUnits(ApplicationDbContext applicationDbContext)
        {
            Unit unit = new Unit
            {
                Name = "kg"
            };
            Unit unit2 = new Unit
            {
                Name = "tbsp"
            };
            Unit unit3 = new Unit
            {
                Name = "g"
            };
            Unit unit4 = new Unit
            {
                Name = "ml"
            };
            Unit unit5 = new Unit
            {
                Name = "pc"
            };
            applicationDbContext.Units.Add(unit);
            applicationDbContext.Units.Add(unit2);
            applicationDbContext.Units.Add(unit3);
            applicationDbContext.Units.Add(unit4);
            applicationDbContext.Units.Add(unit5);
            applicationDbContext.SaveChanges();

            Ingredient ingredient1 = new Ingredient
            {
                Name = "tészta",
                Unit = unit3
            };
            Ingredient ingredient2 = new Ingredient
            {
                Name = "mák",
                Unit = unit3
            };
            Ingredient ingredient3 = new Ingredient
            {
                Name = "porcukor",
                Unit = unit3
            };
            Ingredient ingredient4 = new Ingredient
            {
                Name = "vaj",
                Unit = unit3
            };

            applicationDbContext.Ingredients.Add(ingredient1);
            applicationDbContext.Ingredients.Add(ingredient2);
            applicationDbContext.Ingredients.Add(ingredient3);
            applicationDbContext.Ingredients.Add(ingredient4);
            applicationDbContext.SaveChanges();

            Recipe recipe = new Recipe
            {
                Name = "Mákostészta",
                ImageUri = "https://helpmealblobcontainer.blob.core.windows.net/devbabics/1/image.jpg"
            };
            applicationDbContext.Recipes.Add(recipe);
            applicationDbContext.SaveChanges();
        }
    }
}



