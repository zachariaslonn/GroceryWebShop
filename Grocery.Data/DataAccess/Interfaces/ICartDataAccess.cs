using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Data.DataAccess.Interfaces
{
    public interface ICartDataAccess
    {
        IEnumerable<Product> GetAll();
        Cart GetById(int id);
        IEnumerable<Cart> Read();
        void Write(Cart cart);
        void UpdateCart(Cart cart);

        void Remove(Product cartItem);
        void SaveItem(Product cartItem);
    }
}
