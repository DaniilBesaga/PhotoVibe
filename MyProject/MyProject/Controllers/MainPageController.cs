using Microsoft.AspNetCore.Mvc;
using MyProject.Extensions;
using MyProject.Services;
using Newtonsoft.Json;

namespace MyProject.Controllers
{
    public class MainPageController : Controller
    {
        private readonly Interface.IStockPhotosService _stockPhotosService;
        public MainPageController(Interface.IStockPhotosService stockPhotosService)
        {
            _stockPhotosService = stockPhotosService;
        }
        public IActionResult Index()
        {
            var photos = _stockPhotosService.GetStockPhotos();

            return View(photos);
        }
        public string GetSearch()
        {
            StockPhotosService one = new StockPhotosService();
            StockPhotoCollectionsService two = new StockPhotoCollectionsService(one);
            Dictionary<string, int> map = new Dictionary<string, int>();
            List<string> arr = one.GetStockPhotos().Select(a => a.MainText).ToList();
            List<int> array = two.GetUrls().Select(a=>a.Urls.Count).ToList();
            for(int i = 0;i< arr.Count;i++)
            {
                if(i>=array.Count)
                {
                    array.Add(0);
                }
                map.Add(arr[i], array[i]);
            }
            return JsonConvert.SerializeObject(map, Formatting.Indented);
        }
        public IActionResult SignOutAccount()
        {
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("reglist");
            TempData["Login"] = "red";
            //return ViewComponent("Category");
            return View();
        }

    }
   
}
