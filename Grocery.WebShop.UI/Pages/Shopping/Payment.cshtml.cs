using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.WebShop.UI.Pages.Shopping
{
    public class PaymentModel : PageModel
    {

        private readonly ICartDataAccess cartDataAccess;
        private readonly ICustomerDataAccess customerDataAccess;
        private readonly IOrderDataAccess orderDataAccess;

        //private const int LoggedInCustomer = 21;

        public PaymentModel(ICartDataAccess cartDataAccess, ICustomerDataAccess customerDataAccess, IOrderDataAccess orderDataAccess)
        {
            this.cartDataAccess = cartDataAccess;
            this.customerDataAccess = customerDataAccess;
            this.orderDataAccess = orderDataAccess;
        }
        public List<Product> ShoppingCart { get; set; }
        public Customer ThisCustomer { get;  set; }
        
        public void OnGet(int id)//CustomerId from cart page
        {
            ThisCustomer = customerDataAccess.GetById(id);//Gets Customer by id
            ShoppingCart = cartDataAccess.GetAll().ToList();//Gets all items in cart          
        }
       

        //public IActionResult OnPostPayment()
        //{
        //    return RedirectToPage("/Receipt", order);     //Send order to /Receipt, OnGet()??

        //}

        //public void OnGet(int id)            //CustomerId from cart page
        //{
        //    var customer = _customerDataAccess.GetById(id);      //Gets Customer by id
        //    var items = _cartDataAccess.GetAll().ToList();     //Gets all items in cart
        //    if (customer != null)                              //If there is a customer
        //    {
        //                                                       //Create an order with CustomerId, items and sets an unique id
        //        order = new Order() { CustomerId = id, ListCartItems = items, OrderId = Guid.NewGuid() };

        //        orderDataAccess.SaveOrder(order);                     //Via instance of IDesCart, call save cartItem
        //    }
        //}
    }
}
