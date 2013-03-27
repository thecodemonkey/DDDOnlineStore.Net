using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class UserRole : Entity
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
