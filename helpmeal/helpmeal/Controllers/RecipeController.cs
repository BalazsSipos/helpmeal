using FoodService.Services.BlobService;
using helpmeal.Models;
using helpmeal.Services.IngredientService;
using helpmeal.Services.UnitService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace helpmeal.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IUnitService unitService;
        private readonly IIngredientService ingredientService;
        private readonly IBlobStorageService blobStorageService;

        public RecipeController(IUnitService unitService, IIngredientService ingredientService, IBlobStorageService blobStorageService)
        {
            this.blobStorageService = blobStorageService;
            this.unitService = unitService;
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Unit> unitlist = new List<Unit>(unitService.FindAll());
            return View(unitlist);
        }
        [HttpPost]
        public IActionResult AddIngredient(string Ingredient_name, string Ingredient_unit)
        {
            Unit unit = unitService.FindUnitByName(Ingredient_unit);
            ingredientService.Addingredient(Ingredient_name, unit);
            return RedirectToAction(nameof(RecipeController.AddRecipe), "Recipe");
        }
        [HttpGet]
        public IActionResult AddRecipe()
        {
            List<Ingredient> ingredients = new List<Ingredient>(ingredientService.FindAll());
            return View(ingredients);
        }
        [HttpPost]
        public IActionResult AddRecipe(string recipe_name, string Ingredient_unit1, int amount1, string CookingMethod)
        {

            return RedirectToAction(nameof(RecipeController.AddRecipe), "Recipe");
        }
    }
}
