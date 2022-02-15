using ecommerce.data.Abstract;
using ecommerce.entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ecommerce.data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(ecommerceContext context): base(context)
        {
            
        }

        private ecommerceContext ecommerceContext
        {
            get {return context as ecommerceContext; }
        }
        public void ClearCart(int cartId)
        {
               var cmd = @"delete from CartItems where CartId=@p0";
               ecommerceContext.Database.ExecuteSqlRaw(cmd,cartId);
        }

        public void DeleteFromCart(int cartId, int productId)
        {
               var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
               ecommerceContext.Database.ExecuteSqlRaw(cmd,cartId,productId);
        }

        public Cart GetByUserId(string userId)
        {
                return ecommerceContext.Carts
                            .Include(i=>i.CartItems)
                            .ThenInclude(i=>i.Product)
                            .FirstOrDefault(i=>i.UserId==userId);
        }

        public override void Update(Cart entity)
        {
               ecommerceContext.Carts.Update(entity);
        } 
    }
}