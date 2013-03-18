using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;                            
using System.Collections.Generic;         
using System.Linq;                        
using System.Text;                         
using System.Threading.Tasks;             

namespace DDD.OnlineStore.Domain.Services
{
    public class AuthenticationService : IDisposable
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public UserRepository UserRepository 
        {
            get 
            {
                return this._userRepository;
            }
        }

        public User Authenticate(string name, string password)
        {
            User user = this._userRepository.GetUserByLoginName(name);

            if (user != null && user.Password.Equals(password))
            {
                return user;
            }
            else
            {
                throw new Exception("User was not found");
            }
        }

        public void Dispose()
        {                       
            this._userRepository.Dispose();
        }
    }
}
