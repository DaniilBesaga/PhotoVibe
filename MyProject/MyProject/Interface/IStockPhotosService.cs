using MyProject.Models;

namespace MyProject.Interface
{
    public interface IStockPhotosService
    {
        public string GetPhotoUrl(string text);
        public StockPhotos GetPhotoId(int Id);
        public IEnumerable<Models.StockPhotos> GetStockPhotos();
    }
}
