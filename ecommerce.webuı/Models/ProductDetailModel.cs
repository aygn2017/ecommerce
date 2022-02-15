using ecommerce.entity;
using System.Collections.Generic;


namespace ecommerce.webui.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}