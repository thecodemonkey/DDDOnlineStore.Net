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
            //this.ShoppingCart = new ShoppingCart();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LoginName { get; set; }
        public string Password { get; set; }

        public int? ShoppingCartID { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
