using System.Collections.Generic;
using System.Linq;
using ecommerce.data.Abstract;
using ecommerce.entity;
using Microsoft.EntityFrameworkCore;


namespace ecommerce.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {

        public EfCoreCategoryRepository(ecommerceContext context): base(context)
        {
            
        }
          
        private ecommerceContext ShopContext
        {
            get {return context as ecommerceContext; }
        }
        public void DeleteFromCategory(int productId, int categoryId)
        {
                var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
                ShopContext.Database.ExecuteSqlRaw(cmd,productId,categoryId);
        }

        public Category GetByIdWithProducts(int categoryId)
        {
                return ShopContext.Categories
                            .Where(i=>i.CategoryId==categoryId)
                            .Include(i=>i.ProductCategories)
                            .ThenInclude(i=>i.Product)
                            .FirstOrDefault();
        }


    }
}