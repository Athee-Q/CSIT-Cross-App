using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CSIT.ZB.Apps.DataModels.Entities;
using CSIT.ZB.Apps.Repository.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CSIT.ZB.Apps.ServiceModels.Services;

namespace CSIT.ZB.Apps.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly CurrentUserService _currentUserService;

        [ObservableProperty]
        private ObservableCollection<Product> _products;

        [ObservableProperty]
        private Product _selectedProduct;

        [ObservableProperty]
        private bool _canAddToCart;

        public ProductViewModel(IProductRepository productRepository, ICartRepository cartRepository, CurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _currentUserService = currentUserService;
            Products = new ObservableCollection<Product>();
            CanAddToCart = _currentUserService.IsUserLoggedIn();

        }

        public void LoadProducts()
        {
            var products = _productRepository.GetAllProducts();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        // Method to load products by subcategory and type of product
        public void LoadParticularProducts(int subCategoryId, int typeOfProductId)
        {
            var products = _productRepository.GetTypeOfProductsBySubCategory(subCategoryId, typeOfProductId);
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        // Refresh the CanAddToCart property based on user status
        public void RefreshCanAddToCart()
        {
            CanAddToCart = _currentUserService.IsUserLoggedIn();
        }

        [RelayCommand]
        public async Task AddToCartAsync(Product product)
        {
            string toastMessage = string.Empty;

            if (!_currentUserService.IsUserLoggedIn())
            {
                toastMessage = "Please log in to add products to the cart";
            }
            else
            {
                _cartRepository.AddToCart(product);
                toastMessage = $"{product.Name} added to cart";
            }

            await ShowToastAsync(toastMessage);
        }

        private async Task ShowToastAsync(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short);
            await toast.Show();
        }   
    }
}
