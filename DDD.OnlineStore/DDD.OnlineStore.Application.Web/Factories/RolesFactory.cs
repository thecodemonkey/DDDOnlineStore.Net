using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Application.Web.Models.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Factories
{
    public class RolesFactory
    {
        public static SelectionItem[] CreateRoleModels(IEnumerable<Role> availableRoles, IEnumerable<Role> rolesAssignedToUser)
        {
            List<SelectionItem> result = new List<SelectionItem>();

            foreach (var role in availableRoles)
            {                                           
                bool isSelected = (rolesAssignedToUser != null && rolesAssignedToUser.Any(r => r.ID == role.ID));

                result.Add(new SelectionItem { Label = role.Name, ID = role.ID, IsSelected = isSelected });
            }

            return result.ToArray();
        }

        public static IEnumerable<Role> CreateDomainRoles(IEnumerable<SelectionItem> selectedItems)
        {                                               
            List<Role> result = new List<Role>();

            if (selectedItems != null)
            {
                foreach (var item in selectedItems)
                {
                    if (item.IsSelected)
                    {
                        var r = new Role { Name = item.Label, ID = item.ID };
                        result.Add(r);
                    }
                }
            }

            return result;
        }
    }
}