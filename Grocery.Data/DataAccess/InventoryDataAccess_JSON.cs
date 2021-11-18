using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grocery.Data.DataAccess
{

    public class InventoryDataAccess_JSON : IInventoryDataAccess
    {
        public List<Product> GetAll()
        {
            return Read();
        }

        public Product GetById(int id)
        {
            return Read().FirstOrDefault(x => x.GroceryID == id);
        }

        public List<Product> Read() //Read inventory Jsonfile
        {
            var jsonResponse = File.ReadAllText(@"C:\Users\gongm\source\repos\Grocery\Grocery.Data\DataSource\Inventory_JSON.json");
            return JsonConvert.DeserializeObject<List<Product>>(jsonResponse);

        }

        public void Write(List<Product> list) //Save to Jsonfile
        {
            var jsonString = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"C:\Users\gongm\source\repos\Grocery\Grocery.Data\DataSource\Inventory_JSON.json", jsonString);

        }
    }
}
