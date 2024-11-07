using CSIT.ZB.Apps.ServiceModels.Models;
using CSIT.ZB.Apps.ServiceModels.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CSIT.ZB.Apps.ViewModels
{
    public class HomeViewModel
    {
        //private readonly ProductService _productService;
        //private ObservableCollection<ProductModel> _products;

        //public ObservableCollection<ProductModel> Products
        //{
        //    get => _products;
        //    set => SetProperty(ref _products, value);
        //}

        //public ICommand AddToCartCommand { get; }

        //public HomeViewModel()
        //{
        //    _productService = new ProductService();
        //    LoadProducts();
        //    AddToCartCommand = new Command<ProductModel>(OnAddToCart);
        //}

        //private void LoadProducts()
        //{
        //    var products = _productService.GetProducts();
        //    Products = new ObservableCollection<ProductModel>(products);
        //}

        //private void OnAddToCart(ProductModel product)
        //{
        //    CartService.Instance.AddProduct(product);
        //}
    }
}
