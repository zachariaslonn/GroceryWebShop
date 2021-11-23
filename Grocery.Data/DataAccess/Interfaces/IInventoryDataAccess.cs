using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Data.DataAccess.Interfaces
{
    public interface IInventoryDataAccess
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        List<Product> Read();
        void Write(List<Product> list);

    }
}
