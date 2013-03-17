using DDD.OnlineStore.Domain.Repositories;
using DDD.OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository _productRepository;
        private ShoppingCartService _shoppingCart;

        public HomeController(ProductRepository productRepository, ShoppingCartService shoppingCartService) 
        {
            this._productRepository = productRepository;
        }

        public ActionResult Index()
        {                                       
            return View(this._productRepository.GetAll());
        }

        [HttpPost]
        public ActionResult AddProductToShoppingCart(string hdnProductID, string hdnQuantity)   
        {                                                                                   
            _shoppingCart.UserBuysProduct(hdnProductID, hdnQuantity, SessionContext.User);

            var products = this._productRepository.GetAll();

            return View("Index", products);
        }
    }
}
