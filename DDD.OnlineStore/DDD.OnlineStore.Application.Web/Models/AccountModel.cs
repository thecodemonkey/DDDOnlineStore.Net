using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Models
{
    public class AccountModel
    {
        [DisplayName("Benutzername")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}