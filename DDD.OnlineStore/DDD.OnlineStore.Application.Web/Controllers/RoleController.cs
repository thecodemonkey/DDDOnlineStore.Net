using DDD.OnlineStore.Application.Web.Services;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class RoleController : EditorControllerBase<Role, RoleRepository>
    {
        private UserRepository _userRepository;

        public RoleController(RoleRepository roleRepository, UserRepository userRepository) : base(roleRepository) 
        {
            this._userRepository = userRepository;
        }

        public ActionResult AssignedRoles(int userID)
        {                                               
            var user = this._userRepository.GetByID(userID);
            var roles = this.Repository.GetAll();

            var assignedRoles = UserAppService.CreateAssignedRoles(roles, user.Roles);

            return View(assignedRoles);
        }    
    } 
}
