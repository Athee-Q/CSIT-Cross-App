using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace CSIT.ZB.Apps.DataModels.Entities
{
    public partial class Cart : ObservableObject
    {
        [ObservableProperty]
        private List<Product> _products = new List<Product>();

        [ObservableProperty]
        private double _totalPrice;

        public int UserId { get; set; }

        public Cart()
        {
            _products = new List<Product>();
            _totalPrice = 0;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            UpdateTotalPrice();
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            TotalPrice = Products.Sum(p => p.Price);
        }
    }
}
