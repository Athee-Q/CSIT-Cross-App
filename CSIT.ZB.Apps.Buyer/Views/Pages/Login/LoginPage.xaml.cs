using CSIT.ZB.Apps.ViewModels;

namespace CSIT.ZB.Apps.Buyer.Views.Pages.Login;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _viewModel;
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}