using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.WebShop.UI.Pages
{

    public class IndexModel : PageModel
    {
        private readonly IInventoryDataAccess inventoryDataAccess;

        public List<Product> Foods { get; set; }


        public IndexModel(IInventoryDataAccess inventoryDataAccess)
        {
            this.inventoryDataAccess = inventoryDataAccess;
        }

        public void OnGet()
        {
            Foods = inventoryDataAccess.GetAll();

        }

        public IActionResult OnPostBuy()
        {
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDetail()
        {
            return Page();
        }





    }


}
