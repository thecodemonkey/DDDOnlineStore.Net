using DDD.OnlineStore.Domain.Model;           
using DDD.OnlineStore.Domain.Repositories;
using System;                         
using System.Collections.Generic;
using System.Linq;         
using System.Web;      
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class ProductController : EditorControllerBase<Product, ProductRepository>
    {
        public ProductController(ProductRepository productRepository) : base(productRepository)
        {
        }
    }
}
