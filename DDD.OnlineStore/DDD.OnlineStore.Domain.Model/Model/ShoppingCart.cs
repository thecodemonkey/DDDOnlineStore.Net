using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class ShoppingCart : OrderBase
    {
        public ShoppingCart() : base() { }

        public ShoppingCart(int userID) : base() 
        {
            this.UserID = userID;
        }

        public string Name { get; set; }

        public void AddProduct(Product product, int quantity) 
        {
            if (product == null)
                throw new Exception("you cann't add an invalid item to the shopping cart!");

            if (quantity == 0)
                throw new Exception("quantity should be bigger than 0 !");
            
            OrderItem existingItem = this.Items.FirstOrDefault(i => i.ProductID == product.ID);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else 
            {
                base.Add(OrderFactory.CreateOrderItem(product, quantity));
            }
        }

        public void ChangeProductQuantity(int productID, int quantity) 
        {
            OrderItem existingItem = this.Items.FirstOrDefault(i => i.ProductID == productID);

            if (existingItem != null)
            {
                existingItem.Quantity = quantity;
            }        
        }

        public void RemoveProduct(int productID) 
        {
            base.Remove(productID);
        }
    }
}
