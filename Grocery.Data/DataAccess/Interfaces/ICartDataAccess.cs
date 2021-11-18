using Grocery.Core.Models;

namespace Grocery.Data.DataAccess.Interfaces
{
    public interface ICartDataAccess
    {
        Cart GetById(int id);
        Cart Read();
        void Write(Cart cart);
        void UpdateCart(Cart cart);


    }
}
