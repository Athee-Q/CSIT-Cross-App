using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSIT.ZB.Apps.ServiceModels.Services;
using CommunityToolkit.Maui.Alerts;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly UserService _userService;
        private readonly CurrentUserService _currentUserService;

        [ObservableProperty]
        private string? _identifier;

        public LoginViewModel(UserService userService, CurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            var user = await _userService.AuthenticateAsync(Identifier); 

            if (user != null)
            {
                _currentUserService.SetCurrentUser(user);
                await _userService.SendOtpAsync(user);
                await Shell.Current.GoToAsync("//OtpPage");
            }
            else
            {
                await ShowToastAsync("User not found.");
            }
        }

        [RelayCommand]
        public async Task ContinueAsGuestAsync()
        {
            _currentUserService.SetGuestUser();
            await Shell.Current.GoToAsync("//HomePage"); // Navigate to home as guest
        }

        private async Task ShowToastAsync(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short);
            await toast.Show();
        }
    }
}
