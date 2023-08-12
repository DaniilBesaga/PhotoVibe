namespace MyProject.Models
{
    public class StockPhotos
    {
        public string Url { get; set; }
        public string MainText { get; set; }
        public string SecondaryText { get; set; }
        public StockPhotos(string url, string maintext, string secondarytext)
        {
            Url = url;
            MainText = maintext;
            SecondaryText = secondarytext;
        }
    }
}
