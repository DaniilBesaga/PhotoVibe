using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Services
{
    public class CartService:Interface.ICartService
    {
       public static List<Models.Cart> L = new List<Models.Cart>();
       public IEnumerable<Models.Cart> GetCarts()
        {
            L.Add(new Models.Cart("Aaaa"));
            return L;
        }
        public void AddCart(Cart C)
        {
            L.Add(new Models.Cart(C.Name));
        }

        
    }
}
