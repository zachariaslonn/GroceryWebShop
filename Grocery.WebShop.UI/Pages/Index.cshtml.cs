using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.WebShop.UI.Pages
{

    public class IndexModel : PageModel
    {
        private readonly IInventoryDataAccess _inventoryDataAccess;

        public List<Product> Products { get; set; }

        public IndexModel(IInventoryDataAccess inventoryDataAccess)
        {
            _inventoryDataAccess = inventoryDataAccess;
            Products = _inventoryDataAccess.GetAll().ToList();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostHome()
        {
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDetail()
        {
            return Page();
        }





    }


}
