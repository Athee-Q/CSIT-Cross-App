using CSIT.ZB.Apps.DataModels.Entities;
using CSIT.ZB.Apps.Repository.Interfaces;
using System.Collections.Generic;

namespace CSIT.ZB.Apps.Repository.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly Cart _cart;

        public CartRepository(int userId)
        {
            _cart = new Cart { UserId = userId };
        }

        public void AddToCart(Product product)
        {
            _cart.AddProduct(product);
        }

        public void RemoveFromCart(Product product)
        {
            _cart.RemoveProduct(product);
        }

        public double GetCartTotal()
        {
            return _cart.TotalPrice;
        }

        public List<Product> GetCartItems()
        {
            return _cart.Products;
        }
    }
}

