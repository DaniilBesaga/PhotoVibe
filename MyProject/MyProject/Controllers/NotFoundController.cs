using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class NotFoundController:Controller
    {
        public IActionResult Index()
        {
                return View();
        }
    }
}
