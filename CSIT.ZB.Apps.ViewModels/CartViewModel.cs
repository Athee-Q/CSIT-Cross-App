using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSIT.ZB.Apps.DataModels.Entities;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using CSIT.ZB.Apps.Repository.Interfaces;

public partial class CartViewModel : ObservableObject
{
    private readonly ICartRepository _cartRepository;

    public ObservableCollection<Product> CartItems { get; } = new();

    [ObservableProperty]
    private double _totalPrice;

    public CartViewModel(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
        LoadCart();
    }

    public void LoadCart()
    {
        var cartProducts = _cartRepository.GetCartItems();
        CartItems.Clear();
        foreach (var product in cartProducts)
        {
            CartItems.Add(product);
        }
        TotalPrice = _cartRepository.GetCartTotal();
    }

    [RelayCommand]
    public async Task RemoveFromCartAsync(Product product)
    {
        _cartRepository.RemoveFromCart(product);
        CartItems.Remove(product);
        TotalPrice = _cartRepository.GetCartTotal();
        var toast = Toast.Make($"{product.Name} removed from cart", ToastDuration.Short);
        await toast.Show();
    }

    [RelayCommand]
    public async Task CheckoutAsync()
    {
        // Checkout logic here...
        await Task.CompletedTask;
    }
}

