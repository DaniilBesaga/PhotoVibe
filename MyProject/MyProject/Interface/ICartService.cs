using MyProject.Models;

namespace MyProject.Interface
{
    public interface ICartService
    {
        public IEnumerable<Models.Cart> GetCarts();
        public void AddCart(Cart C);
    }
}
