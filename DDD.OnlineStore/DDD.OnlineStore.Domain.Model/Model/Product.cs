using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class Product : Entity
    {
        public Product() 
        {
            this.Categories = new List<Category>();
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
