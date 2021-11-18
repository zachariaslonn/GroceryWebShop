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

        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public Product Product { get; private set; }
        public Cart Cart { get; private set; }

        public DetailsModel(ICartDataAccess cartDataAccess, IInventoryDataAccess inventoryDataAccess) //
        {

            this.cartDataAccess = cartDataAccess;
            this.inventoryDataAccess = inventoryDataAccess;
        }


        public void OnGet(int id)
        {
            Product = inventoryDataAccess.GetById(id); //Search through all inventory item and find specific id, and return true or false.
        }

        public IActionResult OnPostAdd()
        {
            Product = inventoryDataAccess.GetById(Id);

            if (ModelState.IsValid)
            {
                Cart = cartDataAccess.GetById(Id);
                Cart.Products.Add(Product);
                cartDataAccess.UpdateCart(Cart);
                return Page();
            }

            return Page();
        }

    }
}
