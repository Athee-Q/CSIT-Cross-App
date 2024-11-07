using CSIT.ZB.Apps.DataModels.Entities;
using CSIT.ZB.Apps.Repository.Interfaces;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.ServiceModels.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private string _otp;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Authenticate using either email or mobile number
        public async Task<User> AuthenticateAsync(string identifier)
        {
            var user = await _userRepository.GetUserByEmailOrMobileAsync(identifier);
            return user;
        }

        // Send OTP for login verification
        public async Task SendOtpAsync(User user)
        {
            _otp = GenerateOtp();
            await ShowOtpNotificationAsync(_otp);

            // Simulate sending OTP via email and mobile (add actual sending logic here)
            Console.WriteLine($"OTP sent to {user.Email} and {user.MobileNumber}: {_otp}");
        }

        // Validate the OTP
        public async Task<bool> ValidateOtpAsync(string otp)
        {
            await Task.Delay(1000); // Simulate some delay
            return _otp == otp;
        }

        // Generate a 6-digit OTP
        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // Show OTP as a Toast notification
        private async Task ShowOtpNotificationAsync(string otp)
        {
            string message = $"Your OTP code is: {otp}";
            var toast = Toast.Make(message, ToastDuration.Long);
            await toast.Show();
        }
    }
}
