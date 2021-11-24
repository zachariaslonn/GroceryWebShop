using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.DataAccess.Interfaces
{
    public interface ICustomerDataAccess
    {
        Customer GetById(int id);
        void Add(Customer customer);
        int GetNewId();
        public IEnumerable<Customer> GetAllCustomers();

    }
}
