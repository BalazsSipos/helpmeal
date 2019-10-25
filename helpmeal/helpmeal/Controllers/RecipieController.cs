using helpmeal.Models;
using helpmeal.Services.IngredientService;
using helpmeal.Services.UnitService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Controllers
{
    
    public class RecipieController : Controller
    {
        private readonly IUnitService unitService;
        private readonly IIngredientService ingredientService;
        public RecipieController(IUnitService unitService, IIngredientService ingredientService)
        {
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
    }
}
