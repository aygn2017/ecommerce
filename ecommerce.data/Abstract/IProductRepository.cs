using ecommerce.entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.data.Abstract
{
    public interface IProductRepository: IRepository<Product>
    {
       Product GetProductDetails(string url);
       Product GetByIdWithCategories(int id);
       List<Product> GetProductsByCategory(string name,int page,int pageSize);
       List<Product> GetSearchResult(string searchString);
       List<Product> GetHomePageProducts();
       int GetCountByCategory(string category);
       void Update(Product entity, int[] categoryIds);
        Task CreateAsync(Product entity);
    }
}