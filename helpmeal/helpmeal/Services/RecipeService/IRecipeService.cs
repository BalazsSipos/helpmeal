using helpmeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Services.RecipeService
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllRecipe();
        Task<Recipe> GetRecipeByIdAsync(long recipeId);
    }
}
