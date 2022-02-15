using ecommerce.entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.business.Abstract
{
    public interface IProductService:IValidator<Product>
    {
        Task<Product> GetById(int id);
        Product GetByIdWithCategories(int id);
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        Task<List<Product>> GetAll();
        bool Create(Product entity);
        Task<Product> CreateAsync(Product entity);
        void Update(Task<Product> entity1, Product entity);
        void Delete(Product entity);
        Task DeleteAsync(Product entity);
        Task UpdateAsync(Product entityToUpdate, Product entity);
        bool Update(Product entity, int[] categoryIds);
        Task UpdateAsync(Task<Product> product, Product entity);
        Task DeleteAsync(Task<Product> product);
        bool Update(Task<Product> entity, int[] categoryIds);
    }
}