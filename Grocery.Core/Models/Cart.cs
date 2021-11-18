using System;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public string CartId { get; set; }

        public DateTime DateCreated { get; set; }

        public double CalculateTotalPrice()
        {
            return Products.Sum(x => x.Price);
        }
    }
}
