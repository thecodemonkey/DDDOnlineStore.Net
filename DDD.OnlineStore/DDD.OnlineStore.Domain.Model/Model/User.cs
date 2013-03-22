using System;                           
using System.Collections.Generic;   
using System.Linq;              
using System.Text;           
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class User : Entity
    {
        public User() 
        {
            this.Roles = new List<Role>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LoginName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
