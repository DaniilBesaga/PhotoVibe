using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Xml.Linq;
using MyProject.Extensions;
using System.Text;

namespace MyProject.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(bool added)
        {
            if (added)
            {
                if (ViewBag.TotalCart == null)
                {
                    var list = HttpContext.Session.Get<List<Item>>("cartitems");
                    if (list != null)
                    {
                        ViewBag.TotalCart = list.Count;
                    }
                    else
                    {
                        ViewBag.TotalCart = 0;
                    }
                }
                ViewBag.TotalCart += 1;
                return Content(ViewBag.TotalCart.ToString());
            }
            else
            {
                var list = HttpContext.Session.Get<List<Item>>("cartitems");
                if (list != null)
                {
                    ViewBag.TotalCart = list.Count;
                }
                else
                {
                    ViewBag.TotalCart = 0;
                }
            }
            if (HttpContext.Session.TryGetValue("token", out byte[] tokenvalue))
            {
                TempData["Login"] = "green";
                var emailBytes = Encoding.UTF8.GetChars(HttpContext.Session.Get("Email"));
                TempData["Email"] = emailBytes;
                var emailBytes1 = TempData["Email"] as char[];
                var email = new string(emailBytes1);
                TempData["Email"] = email;
            }
            else
            {
                TempData["Login"] = "red";
            }
            return View("Category", ViewBag.TotalCart.ToString());
        }
        //[HttpPut]
        //public async Task<IViewComponentResult> GetSpan([FromBody]int number)
        //{
        //    ViewBag.Span = ++number;
        //    return View("Category", new { id = ViewBag.Span });
        //}
        //public IViewComponentResult My(string data)
        //{
        //    ViewBag.Span = Convert.ToInt32(data);
        //    return View(data);
        //}
    }
}
