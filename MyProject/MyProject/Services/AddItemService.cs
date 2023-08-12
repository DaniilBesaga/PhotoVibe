using MyProject.Interface;

namespace MyProject.Services
{
    public class AddItemService
    {
        public Models.Item GetItem(string url)
        {
            return GetUrls().Where(a => a.ImgUrl == url).ToList().ElementAt(0);
        }
        public IEnumerable<Models.Item> GetUrls()
        {
            return new List<Models.Item>
            {
                new Models.Item("https://www.photocase.com/photos/115019-mademoiselle-young-lady-woman-red-lips-photocase-stock-photo-medium.jpeg",
                'M', 15.99, false, false, false, false, "#123451"),
                new Models.Item("https://www.photocase.com/photos/141006-businessman-man-tie-businesspeople-earnest-photocase-stock-photo-medium.jpeg",
                'M', 19.99, false, false, false, false, "#123452"),
                 new Models.Item("https://www.photocase.com/photos/2393132-cuddly-soft-shopping-luxury-elegant-wellness-life-photocase-stock-photo-medium.jpeg",
                'M', 23.99, false, false, false, false, "#123453"),  
            };
        }
    }
}
