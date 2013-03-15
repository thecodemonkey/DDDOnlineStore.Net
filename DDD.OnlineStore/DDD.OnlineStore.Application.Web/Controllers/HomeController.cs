using DDD.OnlineStore.Domain.Repositories;
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

        public HomeController(ProductRepository productRepository) 
        {
            this._productRepository = productRepository;
        }

        public ActionResult Index()
        {
            return View(this._productRepository.GetAll());
        }
    }
}
