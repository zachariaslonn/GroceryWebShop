using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grocery.WebShop.UI.Pages.Shopping
{
    public class CheckoutModel : PageModel
    {
        private readonly ICartDataAccess cartDataAccess;
        private readonly ICustomerDataAccess customerDataAccess;
        private const int LoggedInCustomer = 21;

        public CheckoutModel(ICartDataAccess cartDataAccess, ICustomerDataAccess customerDataAccess)
        {
            this.cartDataAccess = cartDataAccess;
            this.customerDataAccess = customerDataAccess;
        }
        public Cart ShoppingCart { get; set; } 
        [BindProperty]
        public string FirstName { get; set; }

        public void OnGet()
        {
            ShoppingCart = cartDataAccess.GetById(LoggedInCustomer);
        }

        public void OnPost()
        {
            var customer = new Customer();
            
            var order = new Order() { IsPaid = true, Products = ShoppingCart.Products, Key = FirstName }; //Create an order.

        }
    }
}
