using System;
using System.Threading.Tasks;

namespace ecommerce.data.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
         ICartRepository Carts {get;}
         ICategoryRepository Categories {get;}
         IOrderRepository Orders {get;}
         IProductRepository Product {get;} 
         void Save();
        Task SaveAsync();
    }
}