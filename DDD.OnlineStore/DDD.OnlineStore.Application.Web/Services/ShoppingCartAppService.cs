using DDD.OnlineStore.Domain.Repositories;
using DDD.OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Services
{
    public class ShoppingCartServiceApp : IDisposable
    {
        private ShoppingCartService _shoppingCartServiceDomain;

        public ShoppingCartServiceApp(ShoppingCartService shoppingCartServiceDomain) 
        {
            this._shoppingCartServiceDomain = shoppingCartServiceDomain;
        }

        public void ChangeProductQuantity(int userID, FormCollection values) 
        {
            Dictionary<int, int> pairsPproductIDQuantityPairs = new Dictionary<int, int>();

            foreach (string key in values.Keys)
            {
                if (key.StartsWith("Menge_"))
                {
                    int productID = int.Parse(key.Substring("Menge_".Length));
                    int quantity = int.Parse(values[key]);

                    pairsPproductIDQuantityPairs.Add(productID, quantity);
                }
            }
           
            this._shoppingCartServiceDomain.ChangeProductQuantity(userID, pairsPproductIDQuantityPairs);
        }

        public ShoppingCartService ShoppingCartServiceDomain
        {
            get 
            {
                return this._shoppingCartServiceDomain;
            }
        }

        public ShoppingCartRepository ShoppingCartRepository 
        {
            get 
            {
                return this._shoppingCartServiceDomain.ShoppingCartRepository;
            }
        }

        public void Dispose()
        {
            this._shoppingCartServiceDomain.Dispose();
        }
    }
}