using CSIT.ZB.Apps.ViewModels;

namespace CSIT.ZB.Apps.Buyer.Views.Pages.Home
{
    public partial class HomePage : ContentPage
    {
        private readonly ProductViewModel _viewModel;

        public HomePage(ProductViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadProducts();

            // Update CanAddToCart based on current user status
            _viewModel.RefreshCanAddToCart();
        }
    }
}
