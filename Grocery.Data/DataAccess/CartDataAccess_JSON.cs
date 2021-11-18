using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Grocery.Data.DataAccess
{
    public class CartDataAccess_JSON : ICartDataAccess
    {
        private readonly IConfiguration configuration;

        public CartDataAccess_JSON(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

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

            var jsonResponse = File.ReadAllText(configuration["ShoppingCartPath"]);
            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                return new Cart();
            }
            return JsonConvert.DeserializeObject<Cart>(jsonResponse);

 

        }

        public void Write(Cart cart)
        {
            var jsonString = JsonConvert.SerializeObject(cart);
            File.WriteAllText(configuration["ShoppingCartPath"], jsonString);
        }
    }
}
