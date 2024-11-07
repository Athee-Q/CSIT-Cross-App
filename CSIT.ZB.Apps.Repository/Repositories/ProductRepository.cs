using CSIT.ZB.Apps.DataModels.Entities;
using CSIT.ZB.Apps.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CSIT.ZB.Apps.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Sample data for demonstration purposes
        private static List<Category> Categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Id = 1,
                            Name = "Phones",
                            TypeOfProducts = new List<TypeOfProduct>
                            {
                                new TypeOfProduct
                                {
                                    Id = 1, Name = "Smartphones",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 1, Name = "iPhone 14", Price = 999.99 },
                                        new Product { Id = 2, Name = "Samsung Galaxy S22", Price = 899.99 },
                                        new Product { Id = 3, Name = "Google Pixel 7", Price = 799.99 }
                                    }
                                },
                                new TypeOfProduct
                                {
                                    Id = 2, Name = "Feature Phones",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 4, Name = "Nokia 3310", Price = 49.99 },
                                        new Product { Id = 5, Name = "Alcatel 1066", Price = 29.99 },
                                        new Product { Id = 6, Name = "Samsung E1200", Price = 19.99 }
                                    }
                                }
                            }
                        },
                        new SubCategory
                        {
                            Id = 2,
                            Name = "Computers",
                            TypeOfProducts = new List<TypeOfProduct>
                            {
                                new TypeOfProduct
                                {
                                    Id = 3, Name = "Laptops",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 7, Name = "MacBook Pro", Price = 1299.99 },
                                        new Product { Id = 8, Name = "Dell XPS 13", Price = 999.99 },
                                        new Product { Id = 9, Name = "HP Spectre x360", Price = 1099.99 }
                                    }
                                },
                                new TypeOfProduct
                                {
                                    Id = 4, Name = "Desktops",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 10, Name = "iMac", Price = 1499.99 },
                                        new Product { Id = 11, Name = "Dell OptiPlex", Price = 799.99 },
                                        new Product { Id = 12, Name = "HP Pavilion", Price = 699.99 }
                                    }
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Id = 2,
                    Name = "Fashion",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Id = 3,
                            Name = "Men's Wear",
                            TypeOfProducts = new List<TypeOfProduct>
                            {
                                new TypeOfProduct
                                {
                                    Id = 5, Name = "Shirts",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 13, Name = "Polo Shirt", Price = 29.99 },
                                        new Product { Id = 14, Name = "T-Shirt", Price = 19.99 },
                                        new Product { Id = 15, Name = "Formal Shirt", Price = 39.99 }
                                    }
                                },
                                new TypeOfProduct
                                {
                                    Id = 6, Name = "Pants",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 16, Name = "Jeans", Price = 49.99 },
                                        new Product { Id = 17, Name = "Chinos", Price = 39.99 },
                                        new Product { Id = 18, Name = "Dress Pants", Price = 59.99 }
                                    }
                                }
                            }
                        },
                        new SubCategory
                        {
                            Id = 4,
                            Name = "Women's Wear",
                            TypeOfProducts = new List<TypeOfProduct>
                            {
                                new TypeOfProduct
                                {
                                    Id = 7, Name = "Dresses",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 19, Name = "Summer Dress", Price = 69.99 },
                                        new Product { Id = 20, Name = "Evening Gown", Price = 149.99 },
                                        new Product { Id = 21, Name = "Casual Dress", Price = 49.99 }
                                    }
                                },
                                new TypeOfProduct
                                {
                                    Id = 8, Name = "Tops",
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 22, Name = "Blouse", Price = 29.99 },
                                        new Product { Id = 23, Name = "Tank Top", Price = 19.99 },
                                        new Product { Id = 24, Name = "Tunic", Price = 39.99 }
                                    }
                                }
                            }
                        }
                    }
                }
            };

        public List<Category> GetCategories()
        {
            return Categories;
        }

        public List<Product> GetProductsByTypeOfProduct(int typeOfProductId)
        {
            var products = Categories
                .SelectMany(c => c.SubCategories)
                .SelectMany(sc => sc.TypeOfProducts)
                .FirstOrDefault(tp => tp.Id == typeOfProductId)?.Products;

            return products ?? new List<Product>();
        }
        public List<Product> GetTypeOfProductsBySubCategory(int subCategoryId, int typeOfProductId)
        {
            var products = Categories
                .SelectMany(c => c.SubCategories)
                .FirstOrDefault(sc => sc.Id == subCategoryId)?
                .TypeOfProducts
                .FirstOrDefault(tp => tp.Id == typeOfProductId)?
                .Products;

            return products ?? new List<Product>();
        }

        public List<SubCategory> GetSubCategoriesByCategoryId(int categoryId)
        {
            var category = Categories.FirstOrDefault(c => c.Id == categoryId);
            return category?.SubCategories ?? new List<SubCategory>();
        }

        public List<Product> GetAllProducts()
        {
            var allProducts = Categories
                .SelectMany(c => c.SubCategories)
                .SelectMany(sc => sc.TypeOfProducts)
                .SelectMany(tp => tp.Products)
                .ToList();

            return allProducts;
        }

    }
}
