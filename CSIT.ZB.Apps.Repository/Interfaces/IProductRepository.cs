using CSIT.ZB.Apps.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Category> GetCategories();
        List<SubCategory> GetSubCategoriesByCategoryId(int categoryId);
        List<Product> GetTypeOfProductsBySubCategory(int subCategoryId, int typeOfProductId);
        List<Product> GetProductsByTypeOfProduct(int subCategoryId);
        List<Product> GetAllProducts();
    }
}
