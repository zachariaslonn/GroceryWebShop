using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Product
    {
        public string Name { get; set; }
        [JsonProperty("imgsrc")]
        public string ImageSrc { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int GroceryID { get; set; }

    }
}
