using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public abstract class OrderBase
    {
        private List<OrderItem> _items;

        public OrderBase() 
        {
            this._items = new List<OrderItem>();
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

        public IEnumerable<OrderItem> Items 
        {
            get 
            {
                return _items.AsReadOnly();
            }
            set 
            {
                this._items = value.ToList();
            }
        }

        protected virtual void Add(OrderItem item)
        {
            if (item == null || item.IsValid)
                throw new Exception("cann't add an invalid item to the order");

            this._items.Add(item);
        }

        protected virtual void Remove(int id)
        {
            this._items.RemoveAll(i => i.ProductID == id);
        }
    }
}
