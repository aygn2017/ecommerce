using ecommerce.entity;
using System.Collections.Generic;


namespace ecommerce.business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
    }
}