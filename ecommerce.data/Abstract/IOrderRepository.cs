using ecommerce.entity;
using System.Collections.Generic;

namespace ecommerce.data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}