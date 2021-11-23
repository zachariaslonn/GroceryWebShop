using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grocery.WebShop.UI.Pages.Shopping
{
    public class DetailsModel : PageModel
    {
        private readonly ICartDataAccess cartDataAccess;
        private readonly IInventoryDataAccess inventoryDataAccess;
        private const int LoggedInCustomer = 21;

        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public Product Product { get; private set; }
        public Cart Cart { get; private set; }

        public DetailsModel(ICartDataAccess cartDataAccess, IInventoryDataAccess inventoryDataAccess) 
        {
            this.cartDataAccess = cartDataAccess;
            this.inventoryDataAccess = inventoryDataAccess;
        }

        public void OnGet(int id)
        {
            Product = inventoryDataAccess.GetById(id);//Search for product id.
        }

        public IActionResult OnPostAdd()//Adds a product to cart.
        {
            Product = inventoryDataAccess.GetById(Id);//Id comes from our page view.

            if (ModelState.IsValid)
            {
                Cart = cartDataAccess.GetById(LoggedInCustomer);
                Cart.Products.Add(Product);
                cartDataAccess.UpdateCart(Cart);
                return Page();
            }

            return Page();
        }

       

    }
}
