using DDD.OnlineStore.Domain.Model;            
using DDD.OnlineStore.Domain.Repositories;
using System;                        
using System.Collections.Generic;
using System.Linq;        
using System.Web;      
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers 
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController(UserRepository userRepository) 
        {
            this._userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var users = this._userRepository.Queryable.OrderBy(p => p.FirstName).ToArray();

            return View(users);
        }

        public ActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                this._userRepository.Insert(user);
                this._userRepository.Save();

                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View("Edit", user);
            }
        }

        public ActionResult Edit(int id)
        {
            var person = this._userRepository.GetByID(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                this._userRepository.Update(user);
                this._userRepository.Save();

                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View(user);
            }
        }

        //[HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                this._userRepository.Delete(id);
                this._userRepository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View("Index");
            }
        }
    }
}
