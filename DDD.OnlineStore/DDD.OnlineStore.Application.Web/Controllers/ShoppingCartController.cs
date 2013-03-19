using DDD.OnlineStore.Application.Web.Common;
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
        private ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService) 
        {
            this._shoppingCartService = shoppingCartService;
        }

        public ActionResult Index()
        {                                   
            var usr = this._shoppingCartService.UserRepository.GetUserByLoginName(this.User.Name);

            ShoppingCart shoppingCart = usr.ShoppingCart;

            return View(shoppingCart);
        }

    }
}
