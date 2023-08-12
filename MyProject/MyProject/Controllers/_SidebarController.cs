using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MyProject.Controllers
{
    public class _SidebarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPut]
        public IActionResult UpdateSpan([FromBody] int i)
        {
            ViewBag.Span = ++i;
            return View();
        }
        [HttpGet]
        public ActionResult Sidebar()
        {
            // здесь может быть код для получения данных для сайдбара
            return PartialView("_Sidebar");
        }
       
    }
}
