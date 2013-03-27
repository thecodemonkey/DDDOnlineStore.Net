using DDD.OnlineStore.Application.Web.Models.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Models
{
    public class UserModel 
    {
        public UserModel() { }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public SelectionItem[] AvailableRoles { get; set; }

        public IEnumerable<SelectionItem> AssignedRoles 
        { 
            get 
            {
                return this.AvailableRoles.Where(r=> r.IsSelected);
            } 
        }
    }
}