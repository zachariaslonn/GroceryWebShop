using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Order
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public bool IsPaid { get; set; } = false;

        

        public double GetTotalCost()
        {
            return Products.Sum(x => x.Price);
        }

    }
}
