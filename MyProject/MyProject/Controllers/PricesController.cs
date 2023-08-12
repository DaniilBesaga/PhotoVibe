using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class PricesController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
