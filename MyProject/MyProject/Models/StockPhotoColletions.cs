namespace MyProject.Models
{
    public class StockPhotoColletions
    {
        public StockPhotos stockPhotos { get; set; }
        public string? Title { get; set; }
        public List<string> Urls { get; set; }
        public StockPhotoColletions(StockPhotos s, string t, List<string> u)
        {
            stockPhotos = s;
            Title = t;
            Urls = u;
        }
    }
}
