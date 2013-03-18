using DDD.OnlineStore.Application.Web.Common;
using DDD.OnlineStore.Domain.Repositories;
using DDD.OnlineStore.Domain.Services;
using System;                       
using System.Collections.Generic;
using System.Linq;           
using System.Web;        
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private ProductRepository _productRepository;
        private ShoppingCartService _shoppingCartService;

        public HomeController(ProductRepository productRepository, ShoppingCartService shoppingCartService) 
        {
            this._productRepository = productRepository;
            this._shoppingCartService = shoppingCartService;
        }

        public ActionResult Index()
        {                                       
            return View(this._productRepository.GetAll());
        }

        [HttpPost]
        public ActionResult AddProductToShoppingCart(int hdnProductID, int hdnQuantity)   
        {                                                                                   
            _shoppingCartService.UserBuysProduct(hdnProductID, hdnQuantity, SessionContext.User.Identity.Name);
            var products = this._productRepository.GetAll();

            return View("Index", products);
        }
    }
}
