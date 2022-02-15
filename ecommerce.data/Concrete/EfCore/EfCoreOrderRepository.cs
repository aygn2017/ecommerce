using System.Collections.Generic;
using System.Linq;
using ecommerce.data.Abstract;
using ecommerce.data.Concrete.EfCore;
using ecommerce.entity;
using Microsoft.EntityFrameworkCore;


namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {

        public EfCoreOrderRepository(ecommerceContext context) : base(context)
        {

        }

        private ecommerceContext ecommerceContext
        {
            get { return context as ecommerceContext; }
        }
        public List<Order> GetOrders(string userId)
        {

            var orders = ecommerceContext.Orders
                                .Include(i => i.OrderItems).ThenInclude(i => i.Product).AsQueryable();

            if (!string.IsNullOrEmpty(userId))
            {
                orders = orders.Where(i => i.UserId == userId);
            }

            return orders.ToList();
        }
    }
}