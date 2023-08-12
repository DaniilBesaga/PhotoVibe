namespace MyProject.Services
{
    public class StockPhotoCollectionsService: Interface.IStockPhotoCollectionsService
    {
        private readonly Interface.IStockPhotosService _stockPhotosService;
        public StockPhotoCollectionsService(Interface.IStockPhotosService stockPhotosService)
        {
            _stockPhotosService = stockPhotosService;
        }
        public IEnumerable<Models.StockPhotoColletions> GetUrls()
        {
            return new List<Models.StockPhotoColletions>
            {
                new Models.StockPhotoColletions(_stockPhotosService.GetPhotoId(0),
                "Who will save the world now? Hardly me alone. Or will I? Times are changing and many people recognise the limits of the market economy based on constant growth, the effects on the environment and the growing social injustice.\r\n\r\nAnswer 1 is: Yes, I can save the world, because there are many of us. And this is how it looks:", new List<string>
                {
                    "https://www.photocase.com/photos/115019-mademoiselle-young-lady-woman-red-lips-photocase-stock-photo-medium.jpeg",
                    "https://www.photocase.com/photos/141006-businessman-man-tie-businesspeople-earnest-photocase-stock-photo-medium.jpeg",
                    "https://www.photocase.com/photos/2393132-cuddly-soft-shopping-luxury-elegant-wellness-life-photocase-stock-photo-medium.jpeg",
                }),
                 new Models.StockPhotoColletions(_stockPhotosService.GetPhotoId(1),
                "Intense hostility and aversion usually deriving from fear, anger, or sense of injury", new List<string>
                {
                    "https://images.photocase.com/p/pngzc5rw/sc42pcfc/photocasesc42pcfc3.jpg?1687242280",
                    "https://images.photocase.com/4/47mxzjkp/57jswggs/photocase57jswggs3.jpg?1687242279",
                    "https://images.photocase.com/c/ce2wumdf/bag2mufq/photocasebag2mufq3.jpg?1687242279",
                    "https://images.photocase.com/5/5qyygxvj/qindn4lz/photocaseqindn4lz3.jpg?1687242280",
                    "https://images.photocase.com/s/sltgkyga/4fnd4sn2/photocase4fnd4sn23.jpg?1687242280",
                    "https://images.photocase.com/7/7dgze5sa/77387775/photocase773877753.jpg?1689067606",
                    "https://images.photocase.com/4/4w69krfe/y99v69ue/photocasey99v69ue3.jpg?1688469482",
                    "https://images.photocase.com/j/jcfw29y2/owl6g9vj/photocaseowl6g9vj3.jpg?1686652602",
                    "https://images.photocase.com/w/wp8gdcxe/imxbfsmd/photocaseimxbfsmd3.jpg?1686652155"
                }),
                  new Models.StockPhotoColletions(_stockPhotosService.GetPhotoId(2),
                "Who will save the world now? Hardly me alone. Or will I? Times are changing and many people recognise the limits of the market economy based on constant growth, the effects on the environment and the growing social injustice.\r\n\r\nAnswer 1 is: Yes, I can save the world, because there are many of us. And this is how it looks:", new List<string>
                {
                    "https://www.photocase.com/photos/115019-mademoiselle-young-lady-woman-red-lips-photocase-stock-photo-medium.jpeg",
                    "https://www.photocase.com/photos/141006-businessman-man-tie-businesspeople-earnest-photocase-stock-photo-medium.jpeg",
                    "https://www.photocase.com/photos/2393132-cuddly-soft-shopping-luxury-elegant-wellness-life-photocase-stock-photo-medium.jpeg",
                }),
            };
        }
    }
}
