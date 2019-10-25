using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        [HttpGet("/menu")]
        public IActionResult Index()
        {
            return View();
        }
    }
}