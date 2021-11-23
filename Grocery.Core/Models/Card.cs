using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Card
    {
        public int CardNumber { get; set; }

        public int CVV { get; set; }

        public string FullName { get; set; }

        public int ExpirationDate { get; set; }

    }
}
