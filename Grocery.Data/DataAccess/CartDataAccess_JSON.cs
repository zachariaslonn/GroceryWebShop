using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grocery.Data.DataAccess
{
    public class CartDataAccess_JSON : ICartDataAccess
    {
        private readonly IConfiguration configuration;

        public CartDataAccess_JSON(IConfiguration configuration)//constructor for Jsonfile path in appsesetting.json
        {
            this.configuration = configuration;
        }
        public Cart GetById(int id)//Read all jsonfile in cart and get that specific cart id.
        {
           var cart = Read().ToList();
           return cart.SingleOrDefault(c => c.CartId == id);          
        }

        public void UpdateCart(Cart cart)
        {
            Write(cart);
        }

        public IEnumerable<Cart> Read()
        {
            var jsonResponse = File.ReadAllText(configuration["ShoppingCartPath"]);//Using the string path in appsettings.json            
            return JsonConvert.DeserializeObject<IEnumerable<Cart>>(jsonResponse);
        }

        public void Write(Cart cart)
        {
            List<Cart> carts = Read().ToList();//Loads all the carts
            carts.RemoveAll(c => c.CartId == cart.CartId);
            carts.Add(cart);
            var jsonString = JsonConvert.SerializeObject(carts);
            File.WriteAllText(configuration["ShoppingCartPath"], jsonString);
        }

        public IEnumerable<Product> GetAll()
        {
            var jsonResponse = File.ReadAllText(configuration["ShoppingCartPath"]);
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonResponse);
        }

        public void SaveItem(Product cartItem)
        {
            var jsonResponse = File.ReadAllText(configuration["ShoppingCartPath"]);
            var items = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonResponse).ToList();
            items.Add(cartItem);            

            var serializedItems = JsonConvert.SerializeObject(items);
            File.WriteAllText(configuration["ShoppingCartPath"], serializedItems); 
        }

        public void Remove(Product cartItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
