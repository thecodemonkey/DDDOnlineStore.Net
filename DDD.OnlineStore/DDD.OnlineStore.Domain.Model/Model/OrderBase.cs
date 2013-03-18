using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public abstract class OrderBase : Entity
    {
        public OrderBase() 
        {
            this.Items = new List<OrderItem>();
        }

        public int QuantityUniqueItems 
        { 
            get
            {
                return this.Items.Count();
            }
        }

        public int QuantityAllItems 
        {
            get 
            {
                return this.Items.Sum(i => i.Quantity);
            }
        }

        public double TotalCosts 
        {
            get 
            {
                return this.Items.Sum(i => i.TotalCosts);
            }
        }

        public virtual ICollection<OrderItem> Items {get; set;}

        protected virtual void Add(OrderItem item)
        {
            if (item == null || item.IsValid == false)
                throw new Exception("cann't add an invalid item to the order");

            this.Items.Add(item);
        }

        protected virtual void Remove(int id)
        {
            var item = this.Items.FirstOrDefault(i => i.ID == id);

            if (item != null) this.Items.Remove(item);
        }
    }
}
