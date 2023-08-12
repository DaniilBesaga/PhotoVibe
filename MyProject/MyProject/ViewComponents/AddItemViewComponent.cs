using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Extensions;
using MyProject.Models;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProject.ViewComponents
{
    [ViewComponent (Name ="AddItem")]
    public class AddItemViewComponent: ViewComponent
    {
        public readonly Services.AddItemService _service;
        private readonly PageContext Context;
        public AddItemViewComponent(Services.AddItemService service)
        {
            _service = service;
        }

        public async Task <IViewComponentResult> InvokeAsync(object url)
        {
            if(url is Dictionary<int, bool>)
            {
                Dictionary<int, bool> D = (Dictionary<int, bool>)url;
                int index = 0;
                bool b = false;
                foreach (KeyValuePair<int, bool> item in D)
                {
                    index = item.Key;
                    b = item.Value;
                }
                List<Item> Items = HttpContext.Session.Get<List<Item>>("items");
                Item i = Items.ElementAt(0);
                int count = 0;
                switch(index)
                {
                    case 0:
                        i.Copyright = b;
                        count = b == true ? count = 70 : count = -70;
                        break;
                    case 1:
                        i.HighPrint = b;
                        count = b == true ? count = 250 : count = -250;
                        break;
                    case 2:
                        i.Templates = b;
                        count = b == true ? count = 250 : count = -250;
                        break;
                    case 3:
                        i.Editoral = b;
                        count = b == true ? count = -3 : count = 3;
                        break;
                }
                i.Price += count;
                HttpContext.Session.Set<List<Item>>("items", Items);
                string json = JsonConvert.SerializeObject(i, Formatting.Indented);
                return Content(json);
            }
            else if(url is int)
            {
                List<Item> Items = HttpContext.Session.Get<List<Item>>("items");
                Item i = Items.ElementAt(0);
                switch(url)
                {
                    case 0:
                        i.Price -= 3;
                        i.Size = 'S';
                        break;
                    case 1:
                        switch(i.Size)
                        {
                            case 'S':
                                i.Price += 3;
                                break;
                            case 'L':
                                i.Price -= 3;
                                break;
                            case 'M':
                                i.Price += 0;
                                break;
                        }
                        i.Size = 'M';
                        break;
                    case 2:
                        i.Price += 3;
                        i.Size = 'L';
                        break;
                }
                HttpContext.Session.Set<List<Item>>("items", Items);
                string json = JsonConvert.SerializeObject(i, Formatting.Indented);
                return Content(json);
            }

            else if(url is string && url!=null)
            {
                var val = HttpContext.Session.Get<List<Item>>("items");
                Item i = val == null?
                    _service.GetUrls().Where(a => a.ImgUrl.Equals(url)).ToList().ElementAt(0) : 
                    val.Where(a => a.ImgUrl.Equals(url)).ToList().ElementAt(0);
                //var i = HttpContext.Session.Get<List<Item>>("items").Where(a => a.ImgUrl == url).ToList().ElementAt(0);
                string json = JsonConvert.SerializeObject(i, Formatting.Indented);
                //return Content("{ \"name\":\"{i}\", \"age\":31, \"city\":\"New York\" }");
                //return Content($"{{ \"name\":\"{i.Price}\", \"age\":31, \"city\":\"New York\" }}");
                return Content(json);
            }

            else if (HttpContext.Session.Get<List<Item>>("items")==null)
            {
                List<Item> items = _service.GetUrls().ToList();
                //ViewBag.Id = "https://www.photocase.com/photos/115019-mademoiselle-young-lady-woman-red-lips-photocase-stock-photo-medium.jpeg";
                HttpContext.Session.Set<List<Item>>("items", items);
            }
           
            //var i = HttpContext.Session.Get<List<Item>>("items").Where(a => a.ImgUrl == url).ToList().ElementAt(0);
            return View("AddItem");
        }
        
    }
}
