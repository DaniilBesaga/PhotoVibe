using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MyProject.Models;
using MyProject.Services;
using Newtonsoft.Json;
using System.Net;

namespace MyProject.Controllers
{
    public class StockPhotoCollectionsController : Controller
    {
        private readonly Interface.IStockPhotoCollectionsService _stockPhotosCollectionService;
        private readonly Interface.IStockPhotosService _stockPhotosService;
        public StockPhotoCollectionsController(Interface.IStockPhotoCollectionsService stockPhotosCollectionService, Interface.IStockPhotosService stockPhotosService)
        {
            _stockPhotosCollectionService = stockPhotosCollectionService;
            _stockPhotosService = stockPhotosService;
        }
        public IActionResult Index()
        {
            string path = Request.Path;
            int value = path.LastIndexOf("/") + 1;
            string e = path.Substring(value, path.Length - value);
            var photos = _stockPhotosCollectionService.GetUrls();
            if (e.Contains('-'))
                e = e.Replace('-', ' ');
            photos = photos.Where(p => p.stockPhotos.MainText.ToLower().Equals(e)).ToList();


            var t2 = photos.Select(a => a.Urls).ToList().ElementAt(0).ToList().ElementAt(0);
            Console.WriteLine(t2);
            return View(photos);
        }
        public IActionResult AddToCart(int i)
        {
            ViewBag.Visibility = "visible";
            return View();
        }
        public IActionResult GetLightBox() 
        {
            string jwtToken = Request.Headers[HeaderNames.Authorization];
            if (jwtToken.Length<30)
            {
                return Unauthorized();
            }
            string i = "Authorize";
            string json = JsonConvert.SerializeObject(i, Formatting.Indented);
            return Content(json);
        }
    }
}
