using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Grocery.WebShop.UI.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartDataAccess cartDataAccess;
        private readonly IInventoryDataAccess inventoryDataAccess;
        private const int LoggedInCustomer = 21;
        public List<Product> CartItems { get; set; }

        public Cart ShoppingCart { get; set; }

        public CartModel(ICartDataAccess cartDataAccess, IInventoryDataAccess inventoryDataAccess)
        {
            CartItems = new List<Product>();
            this.cartDataAccess = cartDataAccess;
            this.inventoryDataAccess = inventoryDataAccess;
        }
        public IActionResult OnGet()//Show the content of the cart.
        {            
            var items = cartDataAccess.GetById(LoggedInCustomer);
            CartItems = items.Products;

            return Page();
        }

        public IActionResult OnGetAdd(int id)//When customer adds a product this method invokes.
        {
            var product = inventoryDataAccess.GetById(id);
            if (product is null)
            {
                return RedirectToPage("/Index");
            }
            var items = cartDataAccess.GetById(LoggedInCustomer);//Currently logged in customer define at the top (Property).

            items.Products.Add(inventoryDataAccess.GetById(id));
            cartDataAccess.UpdateCart(items);
            CartItems = items.Products;

            return RedirectToPage("/Shopping/Cart");
        }

        public IActionResult OnGetRemove(int id) //Read the index in the list and removes it then upadates the cart.
        {            
            var items = cartDataAccess.GetById(LoggedInCustomer);
            items.Products.RemoveAt(id);
            cartDataAccess.UpdateCart(items);

            return RedirectToPage("/Shopping/Cart"); //Back to shopping cart.
        }

        public IActionResult OnPostCheckout()
        {
            return RedirectToPage("/Shopping/Payment");
        }
    }
}
