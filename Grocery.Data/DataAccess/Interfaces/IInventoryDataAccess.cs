using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.DataAccess.Interfaces
{
    public interface IInventoryDataAccess
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> Read();
        void Write(List<Product> list);


    }
}
