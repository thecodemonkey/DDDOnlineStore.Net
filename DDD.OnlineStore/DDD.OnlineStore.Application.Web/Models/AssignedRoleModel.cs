using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Models
{
    public class AssignedRoleModel
    {
        public AssignedRoleModel() { }

        public string Name { get; set; }
        public int RoleID { get; set; }

        public bool IsAssigned { get; set; }
    }
}