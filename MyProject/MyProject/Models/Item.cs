namespace MyProject.Models
{
    public class Item
    {
        public string ImgUrl { get; set; }
        public char Size { get; set; }
        public double Price { get; set; }
        public bool Copyright { get; set; }
        public bool HighPrint { get; set; }
        public bool Templates { get; set; }
        public bool Editoral { get; set; }
        public string Id { get; set; }
        public Item(string ImgUrl, char Size, double Price, bool Copyright, bool HighPrint, bool Templates, bool Editoral, string Id)
        {
                this.ImgUrl = ImgUrl;
                this.Size = Size;
                this.Price = Price;
                this.Copyright = Copyright;
                this.HighPrint = HighPrint;
                this.Templates = Templates;
                this.Editoral = Editoral;
                this.Id = Id;
        }
    }
}
