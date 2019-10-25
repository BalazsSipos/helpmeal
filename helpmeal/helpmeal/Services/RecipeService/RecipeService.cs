using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RecipeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<Recipe>> GetAllRecipe()
        {
            var recipeList = await applicationDbContext.Recipes.ToListAsync();
            return recipeList;
        }

        public async Task<Recipe> GetRecipeByIdAsync(long recipeId)
        {
            var recipe = await applicationDbContext.Recipes.FirstOrDefaultAsync(r => r.RecipeId == recipeId);
            return recipe;
        }
    }
}
