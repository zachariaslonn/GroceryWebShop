using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Grocery.WebShop.UI.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartDataAccess cartDataAccess;
        private readonly IInventoryDataAccess inventoryDataAccess;
        private readonly ICustomerDataAccess customerDataAccess;
        private readonly IOrderDataAccess orderDataAccess;
        private const int LoggedInCustomer = 21;
        public List<Product> CartItems { get; set; }
        public Cart ShoppingCart { get; set; } 
        public Order Order { get; set; }

        public CartModel(ICartDataAccess cartDataAccess, IInventoryDataAccess inventoryDataAccess, ICustomerDataAccess customerDataAccess, IOrderDataAccess orderDataAccess)
        {
            CartItems = new List<Product>(); 
            this.cartDataAccess = cartDataAccess;
            this.inventoryDataAccess = inventoryDataAccess;
            this.customerDataAccess = customerDataAccess;
            this.orderDataAccess = orderDataAccess;
        }


        [BindProperty]
        public int custId { get; set; }
        public IActionResult OnGet()//Show the content of the cart.
        {            
            var items = cartDataAccess.GetById(LoggedInCustomer);
            CartItems = items.Products;
            Customer customer = customerDataAccess.GetById(LoggedInCustomer); 
            if (customer != null)
            {
                Order = new Order() { IsPaid = true, Products = CartItems, CustomerId = LoggedInCustomer, OrderId = Guid.NewGuid() }; //Create an order. 

                orderDataAccess.Save(Order);
            }
            
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


        public IActionResult OnPostPayment() //id = CustomerId from cart page
        {
            return RedirectToPage("/Shopping/Payment", Order);
        }
    }
}
