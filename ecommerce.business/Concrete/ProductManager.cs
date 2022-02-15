using ecommerce.business.Abstract;
using ecommerce.data.Abstract;
using ecommerce.entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitofwork;
        public ProductManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Product entity)
        {
            if (Validation(entity))
            {
                _unitofwork.Product.Create(entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public  async Task<Product> CreateAsync(Product entity)
        {
             _unitofwork.Product.CreateAsync(entity);
             _unitofwork.SaveAsync();
            return entity;
        }

        public void Delete(Product entity)
        {
            // iş kuralları
            _unitofwork.Product.Delete(entity);
            _unitofwork.Save();
        }

        public  async Task DeleteAsync(Product entity)
        {
            _unitofwork.Product.Delete(entity);
            await _unitofwork.SaveAsync();
        }

        public Task DeleteAsync(Task<Product> product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            return  _unitofwork.Product.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return  _unitofwork.Product.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _unitofwork.Product.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _unitofwork.Product.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _unitofwork.Product.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _unitofwork.Product.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _unitofwork.Product.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _unitofwork.Product.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            _unitofwork.Product.Update(entity);
            _unitofwork.Save();
        }

        public bool Update(Product entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelisiniz.";
                    return false;
                }
                _unitofwork.Product.Update(entity, categoryIds);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public void Update(Task<Product> entity1, Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Task<Product> entity, int[] categoryIds)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product entityToUpdate, Product entity)
        {
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Price = entity.Price;
            entityToUpdate.Description = entity.Description;

           await  _unitofwork.SaveAsync();
        }

        public Task UpdateAsync(Task<Product> product, Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Validation(Product entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz.\n";
                isValid = false;
            }

            if (entity.Price < 0)
            {
                ErrorMessage += "ürün fiyatı negatif olamaz.\n";
                isValid = false;
            }

            return isValid; throw new NotImplementedException();
        }
    }
}