using DDD.OnlineStore.Domain.Model;             
using DDD.OnlineStore.Domain.Repositories;
using System;                           
using System.Collections.Generic;       
using System.Linq;                  
using System.Text;              
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Services
{
    public class ShoppingCartService
    {
        private ProductRepository _productRepository;
        private UserRepository _userRepository;

        public ShoppingCartService(ProductRepository productRepository, UserRepository userRepository) 
        {
            this._productRepository = productRepository;
            this._userRepository = userRepository;
        }

        public void UserBuysProduct(int productID, int quantity, string userName)        
        {                                                                       
            User user = this._userRepository.GetUserByLoginName(userName);
            Product product = this._productRepository.GetByID(productID);

            user.ShoppingCart.AddProduct(product, quantity);            

            this._userRepository.Save();
        }
    }
}
