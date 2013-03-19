using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;                    
using System.Collections.Generic;
using System.Linq;             
using System.Text;           
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class OrderItem : Entity
    {
        public OrderItem() 
        {
            this.Quantity = 1;
        }

        //public int ShoppingCartID { get; set; }
        //public virtual ShoppingCart ShoppingCart { get; set; }

        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double PriceOfSingleProduct { get; set; }

        public double TotalCosts 
        {
            get
            {
                return this.Quantity * PriceOfSingleProduct;
            }
        }
        public bool IsValid
        {
            get
            {
                return this.ProductID > 0;
            }
        }
    }
}
