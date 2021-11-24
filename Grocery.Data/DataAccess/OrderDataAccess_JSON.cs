using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grocery.Data.DataAccess
{
    public class OrderDataAccess_JSON : IOrderDataAccess
    {
        private readonly IConfiguration configuration;

        public OrderDataAccess_JSON(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Order> GetAll() //Load all order jsonfile.
        {
            var jsonText = File.ReadAllText(configuration["OrderPath"]);
            return JsonConvert.DeserializeObject<List<Order>>(jsonText);
        }

        public Order GetById(System.Guid Id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Order order) //If the customerId and orderId is the same as the order that's to be saved, remove the old order and save a new one.
        {
            List<Order> orders = GetAll().ToList();
            orders.RemoveAll(o =>( o.CustomerId == order.CustomerId) && (o.OrderId == order.OrderId));
            orders.Add(order);
            var jsonText = JsonConvert.SerializeObject(orders);
            File.WriteAllText(configuration["OrderPath"], jsonText);
        }

        
    }
}
