using DDD.OnlineStore.Application.Web.Common;
using DDD.OnlineStore.Application.Web.Services;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class ShoppingCartController : ControllerBase
    {
        private ShoppingCartServiceApp _shoppingCartService;

        public ShoppingCartController(ShoppingCartServiceApp shoppingCartService) 
        {
            this._shoppingCartService = shoppingCartService;
        }

        public ActionResult Index()
        {
            var shoppingCart = this._shoppingCartService.ShoppingCartRepository.GetByUserID(this.User.UserID);

            return View(shoppingCart);
        }

        [HttpPost]
        public ActionResult Index(FormCollection values) 
        {                                                       
            this._shoppingCartService.ChangeProductQuantity(this.User.UserID, values);

            return this.Index();
        }

        [HttpPost]
        public ActionResult PurchaseCurrentShoppingCart() 
        {                                                               
            this._shoppingCartService.ShoppingCartServiceDomain.Purchase(this.User.UserID);

            return this.View("Index", null);
        }
    }
}
