using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Grocery.Data.DataAccess
{
    public class CartDataAccess_JSON : ICartDataAccess
    {
        public Cart GetById(int id)
        {
            var cart = Read();
            if (cart.Products is null)
            {
                cart.Products = new List<Product>();
            }
            return cart;
        }

        public void UpdateCart(Cart cart)
        {
            Write(cart);
        }

        public Cart Read()
        {
            var jsonResponse = File.ReadAllText(@"C:\Users\gongm\source\repos\Grocery\Grocery.Data\DataSource\ShoppingCart.json");
            return JsonConvert.DeserializeObject<Cart>(jsonResponse);
        }

        public void Write(Cart cart)
        {
            var jsonString = JsonConvert.SerializeObject(cart);
            File.WriteAllText(@"C:\Users\gongm\source\repos\Grocery\Grocery.Data\DataSource\ShoppingCart.json", jsonString);
        }
    }
}
