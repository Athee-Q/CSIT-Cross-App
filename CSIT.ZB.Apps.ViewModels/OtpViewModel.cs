using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSIT.ZB.Apps.ServiceModels.Services;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSIT.ZB.Apps.ViewModels
{
    public partial class OtpViewModel : ObservableObject
    {
        private readonly UserService _userService;

        public string Otp { get; set; }

        public OtpViewModel(UserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        private async void OnSubmitOtp()
        {
            if (string.IsNullOrEmpty(Otp))
            {
                // Show validation error
                await ShowToastAsync("Please enter OTP.");

                return;
            }

            // Validate OTP
            var isValid = await _userService.ValidateOtpAsync(Otp);
            if (isValid)
            {
                // Navigate to the main page (tabbed interface)
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                // Show OTP validation failure message
                await ShowToastAsync("Invalid OTP. Please try again.");

            }
        }

        private async Task ShowToastAsync(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short);
            await toast.Show();
        }

    }

}
