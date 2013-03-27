using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDD.OnlineStore.Domain.Services;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Common;
using Rhino.Mocks;
using DDD.OnlineStore.Domain.Repositories;

namespace DDD.OnlineStore.Domain.UnitTests.ServiceTests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        string name = "customUSER";
        string password = "pwd";
        AuthenticationService _authService;

        [TestInitialize]
        public void RunBeforeEachTest() 
        {
            //arrange
            var dummyAccounts = new[]{
                new User{ LoginName = name, Password = password},
                new User{ LoginName = "another one", Password = "pwd another one"}
            };

            IRepository<User> accountRepository = MockRepository.GenerateStub<IRepository<User>>();
            accountRepository.Stub(x => x.Queryable)
                         .Return(dummyAccounts.AsQueryable());

            UserRepository accRp = new UserRepository(accountRepository);
            _authService = new AuthenticationService(accRp);        
        }

        [TestMethod]
        public void AuthenticateUser_Successfull()
        {
            //act
            User account = _authService.Authenticate(name, password);

            //assert
            Assert.IsNotNull(account, "authentication failed!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "no exception was thrown")]
        public void AuthenticateUser_ExpectException() 
        {
            _authService.Authenticate("notexistinguser", null);
        }
    }
}
