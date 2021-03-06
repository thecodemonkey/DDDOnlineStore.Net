﻿using DDD.OnlineStore.Domain.Model;                 
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
            context.Database.ExecuteSqlCommand("ALTER TABLE ShoppingCarts ADD CONSTRAINT uc_ShoppingCart UNIQUE(UserID)");

            var roles = new List<Role>
            {
                new Role{ Name = "User" },
                new Role{ Name = "Administrator" },
            };

            roles.ForEach(r => context.RoleSet.Add(r));

            var accounts = new List<User>
            {
               new User { LoginName = "Foo", Password = "Bar", FirstName = "Max", LastName = "Mustermann"},
               new User { LoginName = "Foo1", Password = "Bar1", FirstName = "Bill",   LastName = "Gates"},
               new User { LoginName = "Foo2", Password = "Bar2", FirstName = "Steve",   LastName = "Jobs"},
               new User { LoginName = "Foo3", Password = "Bar3", FirstName = "Steve",   LastName = "Woznijak"},
               new User { LoginName = "Foo4", Password = "Bar4", FirstName = "Sergej",   LastName = "Brin"},
               new User { LoginName = "Foo5", Password = "Bar5", FirstName = "Larry",   LastName = "Page"},
               new User { LoginName = "Foo6", Password = "Bar6", FirstName = "Larry",   LastName = "Ellison"},
               new User { LoginName = "Foo7", Password = "Bar7", FirstName = "Pierre",   LastName = "Omidyar"}
            };

            accounts[0].Roles = roles;
            accounts[1].Roles.Add(roles[0]);
            accounts[2].Roles.Add(roles[1]);

            accounts.ForEach(s => context.UserSet.Add(s));

            var categories = new List<Category>
            {
                new Category { Name = "Shuhe" },
                new Category { Name = "T-Shirt" }
            };

            var products = new List<Product>
            {
                new Product { Name = "myNewProduct", Price = 20, Quantity = 5 },
                new Product { Name = "secondproduct", Price = 10, Quantity = 2 }
            };

            products[0].Categories.Add(categories[0]);
            products[0].Categories.Add(categories[1]);
            products[1].Categories.Add(categories[1]);

            products.ForEach(p => context.ProductSet.Add(p));

            context.SaveChanges();
        }
    }
}
