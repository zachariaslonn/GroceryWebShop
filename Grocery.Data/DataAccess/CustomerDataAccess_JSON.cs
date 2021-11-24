using Grocery.Core.Models;
using Grocery.Data.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.DataAccess
{
    public class CustomerDataAccess_JSON : ICustomerDataAccess
    {
        private readonly IConfiguration configuration;

        public CustomerDataAccess_JSON(IConfiguration configuration)//constructor for Jsonfile path in appsesetting.json
        {
            this.configuration = configuration;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var jsonResponse = File.ReadAllText(configuration["CustomerPath"]);
            return JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonResponse);
        }

        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            foreach(Customer customer in GetAllCustomers().ToList())
            {
                if(customer.ID == id)
                {
                    return customer;
                }
            }
            return null;


        }

        public int GetNewId()
        {
            throw new NotImplementedException();
        }

       
    }
}
