using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class HelpController:Controller
    {
        public IActionResult Index()
        {
           return View();
        }
    }
}
