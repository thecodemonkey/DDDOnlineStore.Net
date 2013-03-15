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
        private UserRepository _accountRepository;

        public HomeController(UserRepository accountRepository) 
        {
            this._accountRepository = accountRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
