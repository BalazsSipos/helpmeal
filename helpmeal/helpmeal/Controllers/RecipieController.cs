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
    public class RecipieController : Controller
    {
        private readonly IUnitService unitService;
        private readonly IIngredientService ingredientService;
        private readonly IBlobStorageService blobStorageService;

        public RecipieController(IUnitService unitService, IIngredientService ingredientService, IBlobStorageService blobStorageService)
        {
            this.blobStorageService = blobStorageService;
            this.unitService = unitService;
            this.ingredientService = ingredientService;
        }

        [HttpGet("/addingredient")]
        public IActionResult Index()
        {
            List<Unit> unitlist = new List<Unit>(unitService.FindAll());
            return View(unitlist);
        }
        [HttpPost("/addingredient")]
        public IActionResult addIngredient(string Ingredient_name, string Ingredient_unit)
        {
            Unit unit = unitService.FindUnitByName(Ingredient_unit);
            ingredientService.Addingredient(Ingredient_name, unit);
            return RedirectToAction(nameof(RecipieController.AddRecipie), "Recipie");
        }
        [HttpGet("/addrecipie")]
        public IActionResult AddRecipie()
        {
            List<Ingredient> ingredients = new List<Ingredient>(ingredientService.FindAll());
            return View(ingredients);
        }
        [HttpPost("/addrecipie")]
        public async Task<IActionResult> addRecipie(string recipie_name, string Ingredient_unit1, string amount1, string Ingredient_unit2, string amount2,
            string Ingredient_unit3, string amount3, string CookingMethod, IFormFile image)
        {
            CloudBlockBlob blob = await blobStorageService.MakeBlobFolderAndSaveImageAsync(recipie_name, image);
            return RedirectToAction(nameof(RecipieController.AddRecipie), "Recipie");
        }
    }
}
