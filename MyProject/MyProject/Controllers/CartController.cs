using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Extensions;
using MyProject.Models;
using MyProject.ViewComponents;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyProject.Controllers
{
    [Produces("application/json")]
    public class CartController : Controller
    {
        public readonly Services.AddItemService _service;
        public CartController(Services.AddItemService service)
        {
            _service = service;
           
        }
        public IActionResult Index()
        {
            var a = HttpContext.Session.Get<List<Item>>("cartitems");
            if(a!=null)
                return View(a);
            else
                return View();
        }
       
        public bool AddingToCart(string url)
        {
            if (HttpContext.Session.Get<List<Item>>("items") == null)
            {
                List<Item> items1 = _service.GetUrls().ToList();
                HttpContext.Session.Set<List<Item>>("items", items1);
            }
            var list = HttpContext.Session.Get<List<Item>>("cartitems");
            if (list == null)
            {
                list = new List<Item>();
            }
            var items = HttpContext.Session.Get<List<Item>>("items");
            var item = items.Where(a => a.ImgUrl.Equals(url)).ToList().ElementAt(0);
            if(!list.Contains(item))
            {
                list.Add(item);
            }
            double temp = 0;
            foreach(var i in list)
            {
                temp += i.Price;
            }
            TempData["TotalPrice"] = "EUR" + Convert.ToString(temp);
            HttpContext.Session.Set<List<Item>>("cartitems", list);
            return true;
        }
        //public IActionResult GetSpan(int listId)
        //{
        //    return ViewComponent("Category", new { listId });
        //}
        //[HttpPost]
        //public IActionResult MyAction([FromBody]string data)
        //{
        //    return ViewComponent("CategoryViewComponent", data);
        //}
        [HttpPost]
        public IActionResult BuyItems()
        {
            HttpContext.Session.Remove("cartitems");
            ViewBag.TotalCart = 0;
            return Json(new { redirectToAction = Url.Action("Index", "MainPage") });
        }

        public IActionResult ReloadEvents(bool added)
        {
            return ViewComponent("Category", added);
        }
        public IActionResult ShowOverlay()
        {
            return ViewComponent("AddItem");
        }
        public IActionResult GetOverlayData(string url)
        {
            return ViewComponent("AddItem", url);
        }
        [HttpGet]
        public IActionResult GetData(int index, bool b, char type)
        { 
            if(type=='b')
            {
                return ViewComponent("AddItem", index);
            }
            else if(type=='c')
            {
                Dictionary<int, bool> D = new Dictionary<int, bool>();
                D.Add(index, b);
                return ViewComponent("AddItem", D);
            }
            return ViewComponent("AddItem", index);
        }
        public IActionResult LightBox()
        {
            return ViewComponent("AddToLightBox");
        }
    }
}
