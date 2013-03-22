using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; protected set; }
    }
}
