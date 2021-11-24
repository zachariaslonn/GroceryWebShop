using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.DataAccess.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();

        Order GetById(Guid Id);

        void SaveOrder(Order order);

    }
}
