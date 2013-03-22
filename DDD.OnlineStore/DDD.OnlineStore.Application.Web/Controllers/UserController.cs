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
        public UserController(UserRepository userRepository) : base(userRepository)
        {

        }
    }
}
