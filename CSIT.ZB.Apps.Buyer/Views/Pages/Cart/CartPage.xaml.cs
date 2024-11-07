using CSIT.ZB.Apps.ViewModels;

namespace CSIT.ZB.Apps.Buyer.Views.Pages.Cart
{
    public partial class CartPage : ContentPage
    {
        public CartPage(CartViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;  // Set BindingContext directly
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (CartViewModel)BindingContext;
            viewModel.LoadCart();  // Load cart when the page appears
        }
    }
}
