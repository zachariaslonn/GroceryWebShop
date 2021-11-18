using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grocery.Data.DataAccess
{

    public class InventoryDataAccess_JSON : IInventoryDataAccess
    {
        private readonly IConfiguration configuration;

        public InventoryDataAccess_JSON(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

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
            try
            {
                var jsonResponse = File.ReadAllText(configuration["InventoryPath"]);
                return JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
            }
            catch (System.Exception)
            {

                return new List<Product>();
            }


        }

        public void Write(List<Product> list) //Save to Jsonfile
        {
            var jsonString = JsonConvert.SerializeObject(list);
            File.WriteAllText(configuration["InventoryPath"], jsonString);

        }
    }
}
