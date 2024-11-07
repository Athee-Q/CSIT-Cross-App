using CSIT.ZB.Apps.Repository.Interfaces;
using CSIT.ZB.Apps.ServiceModels.Models;
using System.Collections.Generic;

namespace CSIT.ZB.Apps.ServiceModels.Services
{
    public class ProductService
    {
        //private readonly IProductRepository _productRepository;

        //public ProductService(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        //public List<ProductModel> GetProductsForCustomer(Customer customer)
        //{
        //    var products = _productRepository.GetProducts();

        //    // Apply business logic: Apply 10% discount for VIP customers
        //    if (customer.IsVIP)
        //    {
        //        products = products.Select(p =>
        //        {
        //            p.Price = p.Price > 100 ? p.Price * 0.9 : p.Price;
        //            return p;
        //        }).ToList();
        //    }

        //    return products.Select(p => new ProductModel
        //    {
        //        Name = p.Name,
        //        Price = p.Price
        //    }).ToList();
        //}
    }

}
