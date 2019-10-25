using Microsoft.AspNetCore.Mvc;

namespace helpmeal.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet("/menu")]
        public IActionResult Index()
        {
            return View();
        }
    }
}