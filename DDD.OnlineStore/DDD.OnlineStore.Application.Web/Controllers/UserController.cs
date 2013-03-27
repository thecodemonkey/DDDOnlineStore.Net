using DDD.OnlineStore.Application.Web.Factories;
using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers 
{
    public class UserController : EditorControllerBase<User, UserRepository>
    {
        private RoleRepository _roleRepository;

        public UserController(UserRepository userRepository, RoleRepository roleRepository) : base(userRepository)
        {
            this._roleRepository = roleRepository;
        }

        public override ActionResult Index()
        {                                      
            var domainUsers = this.Repository.GetAll();
            var viewModelUsers = UserFactory.CreateUserModelList(domainUsers, this._roleRepository);
            
            return View(viewModelUsers);
        }

        public ActionResult CreateUser()
        {
            var viewModelUser = new UserModel();
            var availableRoles = this._roleRepository.GetAll();

            viewModelUser.AvailableRoles = RolesFactory.CreateRoleModels(availableRoles, null);

            return View("Edit", viewModelUser);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel userModel) 
        { 
            var domainUser = UserFactory.CreateDomainUser(userModel);
            return base.Create(domainUser);
        }

        public ActionResult EditUser(int id)
        {                                           
            var domainUser = this.Repository.GetByID(id);
            var viewModelUser = UserFactory.CreateUserModel(domainUser, this._roleRepository);
            
            return View("Edit", viewModelUser);
        }

        [HttpPost]
        public ActionResult EditUser(UserModel userModel)
        {
            var domainUser = UserFactory.CreateDomainUser(userModel);
            return base.Edit(domainUser);
        }
    }
}
