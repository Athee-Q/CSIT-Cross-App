using CommunityToolkit.Maui;
using CSIT.ZB.Apps.Buyer.Views.Pages.Home;
using CSIT.ZB.Apps.Buyer.Views.Pages.Cart;
using CSIT.ZB.Apps.Buyer.Views.Pages.Login;
using CSIT.ZB.Apps.Buyer.Views.Pages.OTP;
using CSIT.ZB.Apps.Repository.Interfaces;
using CSIT.ZB.Apps.Repository.Repositories;
using CSIT.ZB.Apps.ServiceModels.Services;
using CSIT.ZB.Apps.ViewModels;
using Microsoft.Extensions.Logging;
using CSIT.ZB.Apps.DataModels.Entities;
using CSIT.ZB.Apps.Buyer.Views.Pages.Profile;

namespace CSIT.ZB.Apps.Buyer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Register services and repositories
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<CurrentUserService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddTransient<ICartRepository>(sp =>
            {
                var currentUserService = sp.GetRequiredService<CurrentUserService>();
                var userId = currentUserService.GetCurrentUserId();
                if (userId == 0)
                {
                    // Guest user has no cart
                    return null;
                }
                return new CartRepository(userId);
            });

            // Register ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<OtpViewModel>();
            builder.Services.AddTransient<ProductViewModel>();
            builder.Services.AddTransient<CartViewModel>();

            // Register Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<OtpPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<ProfilePage>();

            return builder.Build();
        }
    }
}
