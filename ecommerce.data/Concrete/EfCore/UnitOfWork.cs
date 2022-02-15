
using ecommerce.data.Abstract;
using System.Threading.Tasks;

namespace ecommerce.data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ecommerceContext _context;
        public UnitOfWork(ecommerceContext context)
        {
            _context = context;
        }

        private EfCoreCartRepository _cartRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreOrderRepository _orderRepository;
        private EfCoreProductRepository _productRepository;

        public ICartRepository Carts =>
            _cartRepository = _cartRepository ?? new EfCoreCartRepository(_context);

        public ICategoryRepository Categories =>
            _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IOrderRepository Orders =>
            (IOrderRepository)(_orderRepository = _orderRepository ?? new EfCoreOrderRepository(_context));

        public IProductRepository Product =>
            _productRepository = _productRepository ?? new EfCoreProductRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class EfCoreOrderRepository
    {
        private ecommerceContext context;

        public EfCoreOrderRepository(ecommerceContext context)
        {
            this.context = context;
        }
    }
}