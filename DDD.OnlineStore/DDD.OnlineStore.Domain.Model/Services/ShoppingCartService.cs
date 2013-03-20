using DDD.OnlineStore.Domain.Factories;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Services
{                                           
    public class ShoppingCartService : IDisposable
    {                                                       
        private ProductRepository _productRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private PurchaseOrderRepository _purchaseOrderRepository;

        public ShoppingCartService(ProductRepository productRepository, 
                                   ShoppingCartRepository userRepository, 
                                   PurchaseOrderRepository purchaseOrderRepository) 
        {
            this._productRepository = productRepository;
            this._shoppingCartRepository = userRepository;
            this._purchaseOrderRepository = purchaseOrderRepository;
        }

        public void AddProductToShoppingCart(int productID, int quantity, int userID)        
        {
            var shoppingCart = this._shoppingCartRepository.GetByUserID(userID);
            Product product = this._productRepository.GetByID(productID);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart(userID);
                this._shoppingCartRepository.Insert(shoppingCart);
            }

            shoppingCart.AddProduct(product, quantity);            

            this._shoppingCartRepository.Save();
        }

        public void ChangeProductQuantity(int userID, Dictionary<int, int> productIDQuantityPairs) 
        {   
            if (productIDQuantityPairs != null && productIDQuantityPairs.Count > 0)
            {
                var shoppingCart = this._shoppingCartRepository.GetByUserID(userID);
        
                foreach(int productID in productIDQuantityPairs.Keys)
                {
                    shoppingCart.ChangeProductQuantity(productID, productIDQuantityPairs[productID]);
                }

                this._shoppingCartRepository.Save();                
            }
        }

        public void Purchase(int userID) 
        {                                           
            var shoppingCart = this._shoppingCartRepository.GetByUserID(userID);

            PurchaseOrder order = OrderFactory.CreatePurchaseOrder(shoppingCart);
            this._purchaseOrderRepository.Insert(order);

            shoppingCart.Items.Clear();
            
            this._shoppingCartRepository.Save();
        }

        public ShoppingCartRepository ShoppingCartRepository
        {
            get 
            {
                return this._shoppingCartRepository;
            }
        }

        public ProductRepository ProductRepository 
        {
            get 
            {
                return this._productRepository;
            }
        }

        public void Dispose()
        {
            this._productRepository.Dispose();
            this._shoppingCartRepository.Dispose();
        }
    }
}
