using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Services
{
    public class UserAppService
    {
        public static AssignedRoleModel[] CreateAssignedRoles(IEnumerable<Role> availableRoles, IEnumerable<Role> rolesAssignedToUser) 
        {
            List<AssignedRoleModel> result = new List<AssignedRoleModel>();

            foreach (var role in availableRoles) 
            {
                bool isAssigned = (rolesAssignedToUser != null && rolesAssignedToUser.Any(r => r.ID == role.ID)); 

                result.Add(new AssignedRoleModel { Name = role.Name, RoleID = role.ID, IsAssigned = isAssigned});
            }

            return result.ToArray();
        }
    }
}