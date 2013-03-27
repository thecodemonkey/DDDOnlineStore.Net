using DDD.OnlineStore.Application.Web.Models;           
using DDD.OnlineStore.Domain.Model;             
using DDD.OnlineStore.Domain.Repositories;  
using System;                               
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Factories
{
    public class UserFactory
    {
        public static IEnumerable<UserModel> CreateUserModelList(IEnumerable<User> users, RoleRepository roleRepository) 
        {
            List<UserModel> list = new List<UserModel>();
            if (users != null) 
            {
                foreach (User user in users) 
                {
                    list.Add(CreateUserModel(user, roleRepository));
                }
            }

            return list.AsReadOnly();
        }

        public static UserModel CreateUserModel(User user, RoleRepository roleRepository) 
        {
            var availableRoles = roleRepository.GetAll();

            return new UserModel
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LoginName = user.LoginName,
                Password = user.Password,
                AvailableRoles = RolesFactory.CreateRoleModels(availableRoles, user.Roles),
            };
        }

        public static User CreateDomainUser(UserModel userModel)
        {                              
            var domainUser = new User
            {                             
                ID = userModel.ID,       
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                LoginName = userModel.LoginName,
                Password = userModel.Password,
                Roles = RolesFactory.CreateDomainRoles(userModel.AssignedRoles).ToList()
            };

            return domainUser;
        }
    }
}