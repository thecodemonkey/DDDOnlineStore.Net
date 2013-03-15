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
            var accounts = new List<User>
            {
               new User { LoginName = "Foo", Password = "Bar", FirstName = "Max", LastName = "Mustermann" },
               new User { LoginName = "Foo1", Password = "Bar1", FirstName = "Bill",   LastName = "Gates" } ,
               new User { LoginName = "Foo2", Password = "Bar2", FirstName = "Steve",   LastName = "Jobs" } ,
               new User { LoginName = "Foo3", Password = "Bar3", FirstName = "Steve",   LastName = "Woznijak" },
               new User { LoginName = "Foo4", Password = "Bar4", FirstName = "Sergej",   LastName = "Brin" } ,
               new User { LoginName = "Foo5", Password = "Bar5", FirstName = "Larry",   LastName = "Page" } ,
               new User { LoginName = "Foo6", Password = "Bar6", FirstName = "Larry",   LastName = "Ellison" },
               new User { LoginName = "Foo7", Password = "Bar7", FirstName = "Pierre",   LastName = "Omidyar" }
            };
            accounts.ForEach(s => context.UserSet.Add(s));




            context.SaveChanges();
        }
    }
}
