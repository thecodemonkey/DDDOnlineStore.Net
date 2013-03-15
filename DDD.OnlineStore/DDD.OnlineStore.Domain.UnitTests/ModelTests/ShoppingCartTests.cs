using DDD.OnlineStore.Domain.Model;                          
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;                               
using System.Collections.Generic;   
using System.Linq;              
using System.Text;              
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.UnitTests.ModelTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void AddItems_3Items_2UniqueProducts_GetsQuantityANDPriceCalculations() 
        {
            //arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            var items = new Product[]{
              new Product { ID = 1, Price = 10, Name = "Product1"  },
              new Product { ID = 2, Price = 100, Name = "Product2" },
              new Product { ID = 1, Price = 10, Name = "Product1"  }
            };
            
            //act
            shoppingCart.AddProduct(items[0], 1);
            shoppingCart.AddProduct(items[1], 1);
            shoppingCart.AddProduct(items[2], 1);

            //assert
            Assert.IsTrue(shoppingCart.QuantityAllItems == 3, "wrong quantity of all tems");
            Assert.IsTrue(shoppingCart.QuantityUniqueItems == 2, "wrong quantity of unique tems");
            Assert.IsTrue(shoppingCart.TotalCosts == 120, "wrong total costs");
        }

        [TestMethod]
        public void Add2Items_Remove1Item_ExpectedAmount_Is_1()                         
        {                                                               
            //arrange                                           
            ShoppingCart shoppingCart = new ShoppingCart();
            
            var items = new Product[]{
              new Product{ ID = 1, Price = 10, Name = "Product1" },
              new Product{ ID = 2, Price = 100, Name = "Product2"}
            };

            //act
            shoppingCart.AddProduct(items[0], 1);
            shoppingCart.AddProduct(items[1], 1);

            shoppingCart.RemoveProduct(2);

            //assert
            Assert.IsTrue(shoppingCart.QuantityAllItems == 1, "wrong quantity of all tems");
            Assert.IsTrue(shoppingCart.Items.ToArray()[0].ProductID == items[0].ID, "wrong item was removed");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "no exception was thrown")]
        public void AddItem_Null_ExpectException() 
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddProduct(null, 0);
        }
    }
}
