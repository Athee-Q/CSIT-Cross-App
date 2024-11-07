using CSIT.ZB.Apps.ViewModels;

namespace CSIT.ZB.Apps.Buyer.Views.Pages.OTP;

public partial class OtpPage : ContentPage
{
	public OtpPage(OtpViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}