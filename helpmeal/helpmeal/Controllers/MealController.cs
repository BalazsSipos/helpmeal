using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace helpmeal.Controllers
{
    public class MealController : Controller
    {
        [HttpGet("/Edit")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Edit")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
