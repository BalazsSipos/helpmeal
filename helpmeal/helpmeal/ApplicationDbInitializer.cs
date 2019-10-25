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
            //var temporalUnit = applicationDbContext.Units.FirstOrDefault(m => m.UnitId == 1);
            //if (temporalUnit.Equals(null))
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
                Unit unit6 = new Unit
                {
                    Name = "slice"
                };
                applicationDbContext.Units.Add(unit);
                applicationDbContext.Units.Add(unit2);
                applicationDbContext.Units.Add(unit3);
                applicationDbContext.Units.Add(unit4);
                applicationDbContext.Units.Add(unit5);
                applicationDbContext.Units.Add(unit6);
                applicationDbContext.SaveChanges();

                Ingredient ingredient1 = new Ingredient
                {
                    Name = "salmon",
                    Unit = unit3
                };
                Ingredient ingredient2 = new Ingredient
                {
                    Name = "green beans",
                    Unit = unit3
                };
                Ingredient ingredient3 = new Ingredient
                {
                    Name = "lemon",
                    Unit = unit5
                };
                Ingredient ingredient4 = new Ingredient
                {
                    Name = "soy sauce",
                    Unit = unit2
                };
                Ingredient ingredient5 = new Ingredient
                {
                    Name = "honey",
                    Unit = unit2
                };
                Ingredient ingredient6 = new Ingredient
                {
                    Name = "mirin",
                    Unit = unit2
                };
                Ingredient ingredient7 = new Ingredient
                {
                    Name = "butternut squash",
                    Unit = unit
                };
                Ingredient ingredient8 = new Ingredient
                {
                    Name = "penne",
                    Unit = unit
                };
                Ingredient ingredient9 = new Ingredient
                {
                    Name = "butter",
                    Unit = unit
                };
                Ingredient ingredient10 = new Ingredient
                {
                    Name = "leek",
                    Unit = unit5
                };
                Ingredient ingredient11 = new Ingredient
                {
                    Name = "flour",
                    Unit = unit
                };
                Ingredient ingredient12 = new Ingredient
                {
                    Name = "milk",
                    Unit = unit4
                };
                Ingredient ingredient13 = new Ingredient
                {
                    Name = "frozen peas",
                    Unit = unit4
                };
                Ingredient ingredient14 = new Ingredient
                {
                    Name = "Cheddar cheese",
                    Unit = unit
                };
                Ingredient ingredient15 = new Ingredient
                {
                    Name = "brown bread",
                    Unit = unit6
                };

                applicationDbContext.Ingredients.Add(ingredient1);
                applicationDbContext.Ingredients.Add(ingredient2);
                applicationDbContext.Ingredients.Add(ingredient3);
                applicationDbContext.Ingredients.Add(ingredient4);
                applicationDbContext.Ingredients.Add(ingredient5);
                applicationDbContext.Ingredients.Add(ingredient6);
                applicationDbContext.Ingredients.Add(ingredient7);
                applicationDbContext.Ingredients.Add(ingredient8);
                applicationDbContext.Ingredients.Add(ingredient9);
                applicationDbContext.Ingredients.Add(ingredient10);
                applicationDbContext.Ingredients.Add(ingredient11);
                applicationDbContext.Ingredients.Add(ingredient12);
                applicationDbContext.Ingredients.Add(ingredient13);
                applicationDbContext.Ingredients.Add(ingredient14);
                applicationDbContext.Ingredients.Add(ingredient15);
                applicationDbContext.SaveChanges();

                Recipe recipe = new Recipe
                {
                    Name = "Teriyaki salmon & green beans",
                    ImageUri = "https://helpmealblobcontainer.blob.core.windows.net/devbabics/2/image.jpg",
                    CookingMethod = "Heat oven to 180C/160C fan/gas 4. If you have a whole piece of salmon, cut it into four fillets. Place a sheet of baking parchment on a baking tray and lay the salmon diagonally across it. Cook the beans in boiling water for 1 min and drain. Arrange the beans in piles around the salmon and add the lemon wedges to the baking tray. Mix the soy sauce, honey, mirin and garlic, and pour half of it over the beans and salmon.  Cook for 15 mins, then pour the rest of the sauce over the salmon. Cook for another 5 mins. Squeeze over the lemon and serve with noodles or rice."
                };

                Recipe recipe2 = new Recipe
                {
                    Name = "3-veg mac 'n' cheese",
                    ImageUri = "https://helpmealblobcontainer.blob.core.windows.net/devbabics/4/gfkids_maccheese.jpg",
                    CookingMethod = "Heat oven to 200C/fan 180C/gas 6. Put the butternut squash in a steamer over boiling water. Steam for around 15-20 mins or until tender. Drain and then blitz in a food processor until smooth. Cook the pasta according to the pack instructions. Heat the butter in a medium saucepan, add the leek and cook for 2 mins. Stir in the flour and cook for 1-2 mins more. Take the pan off the heat and gradually whisk in the milk. Return to the heat and bring to the boil, stirring all the time. Simmer for 5 mins. Stir in the peas and bring back to a simmer. Take the pan off the heat and stir in the butternut squash, then 125g cheese. Stir the pasta into the sauce and transfer to an ovenproof dish. Sprinkle over the remaining cheese and the breadcrumbs. Bake for 20 mins or until golden and bubbling."
                };
                applicationDbContext.Recipes.Add(recipe);
                applicationDbContext.Recipes.Add(recipe2);
                applicationDbContext.SaveChanges();

                RecipeIngredient recipeIngredient = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient1,
                    Amount = 500
                };
                RecipeIngredient recipeIngredient2 = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient2,
                    Amount = 100
                };
                RecipeIngredient recipeIngredient3 = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient3,
                    Amount = 1
                };
                RecipeIngredient recipeIngredient4 = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient4,
                    Amount = 2
                };
                RecipeIngredient recipeIngredient5 = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient4,
                    Amount = 1
                };
                RecipeIngredient recipeIngredient6 = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient4,
                    Amount = 1
                };
                RecipeIngredient recipeIngredient7 = new RecipeIngredient
                {
                    Recipe = recipe,
                    Ingredient = ingredient4,
                    Amount = 1
                };
                RecipeIngredient recipeIngredient8 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient7,
                    Amount = 150
                };
                RecipeIngredient recipeIngredient9 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient8,
                    Amount = 300
                };
                RecipeIngredient recipeIngredient10 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient9,
                    Amount = 40
                };
                RecipeIngredient recipeIngredient11 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient10,
                    Amount = 1
                };
                RecipeIngredient recipeIngredient12 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient11,
                    Amount = 25
                };
                RecipeIngredient recipeIngredient13 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient12,
                    Amount = 600
                };
                RecipeIngredient recipeIngredient14 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient13,
                    Amount = 100
                };
                RecipeIngredient recipeIngredient15 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient14,
                    Amount = 175
                };
                RecipeIngredient recipeIngredient16 = new RecipeIngredient
                {
                    Recipe = recipe2,
                    Ingredient = ingredient15,
                    Amount = 1
                };
                applicationDbContext.RecipeIngredient.Add(recipeIngredient);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient2);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient3);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient4);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient5);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient6);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient7);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient8);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient9);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient10);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient11);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient12);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient13);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient14);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient15);
                applicationDbContext.RecipeIngredient.Add(recipeIngredient16);
                applicationDbContext.SaveChanges();



            }
        }
    }
}



