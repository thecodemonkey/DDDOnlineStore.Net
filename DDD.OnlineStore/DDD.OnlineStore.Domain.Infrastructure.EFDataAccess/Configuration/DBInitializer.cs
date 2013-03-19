using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Configuration
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<EFDomainContext>
    {
        protected override void Seed(EFDomainContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_ShoppingCart UNIQUE(ShoppingCartID)");

            var accounts = new List<User>
            {
               new User { LoginName = "Foo", Password = "Bar", FirstName = "Max", LastName = "Mustermann", ShoppingCart = new ShoppingCart() } ,
               new User { LoginName = "Foo1", Password = "Bar1", FirstName = "Bill",   LastName = "Gates", ShoppingCart = new ShoppingCart() } ,
               new User { LoginName = "Foo2", Password = "Bar2", FirstName = "Steve",   LastName = "Jobs", ShoppingCart = new ShoppingCart() } ,
               new User { LoginName = "Foo3", Password = "Bar3", FirstName = "Steve",   LastName = "Woznijak", ShoppingCart = new ShoppingCart() },
               new User { LoginName = "Foo4", Password = "Bar4", FirstName = "Sergej",   LastName = "Brin", ShoppingCart = new ShoppingCart() } ,
               new User { LoginName = "Foo5", Password = "Bar5", FirstName = "Larry",   LastName = "Page", ShoppingCart = new ShoppingCart() } ,
               new User { LoginName = "Foo6", Password = "Bar6", FirstName = "Larry",   LastName = "Ellison", ShoppingCart = new ShoppingCart() },
               new User { LoginName = "Foo7", Password = "Bar7", FirstName = "Pierre",   LastName = "Omidyar", ShoppingCart = new ShoppingCart() }
            };

            accounts.ForEach(s => context.UserSet.Add(s));

            var products = new List<Product>
            {
                new Product { Name = "myNewProduct", Price = 20, Quantity = 5 },
                new Product { Name = "secondproduct", Price = 10, Quantity = 2 }
            };
            products.ForEach(p => context.ProductSet.Add(p));

            context.SaveChanges();
        }
    }
}
