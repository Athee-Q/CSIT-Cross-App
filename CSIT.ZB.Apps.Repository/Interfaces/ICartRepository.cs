using CSIT.ZB.Apps.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.Repository.Interfaces
{
    public interface ICartRepository
    {
        void AddToCart(Product product);
        void RemoveFromCart(Product product);
        double GetCartTotal();
        List<Product> GetCartItems();
    }
}
