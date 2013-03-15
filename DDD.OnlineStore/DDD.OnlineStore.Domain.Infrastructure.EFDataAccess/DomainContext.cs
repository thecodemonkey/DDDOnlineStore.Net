using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common;
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Configuration;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess
{
    public class DomainContext : DbContext, IDomainContext
    {
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<Order> OrderSet { get; set; }
        public virtual DbSet<Product> ProductSet { get; set; }

        public IRepository<User> Users
        {
            get { return new GenericRepository<User>(this); }
        }

        public IRepository<Order> Orders
        {
            get { return new GenericRepository<Order>(this); }
        }

        public IRepository<Product> Products 
        {
            get { return new GenericRepository<Product>(this); }
        }

        static DomainContext() { QueryableExtensions.Includer = new DbIncluder(); }
            
        private class DbIncluder : QueryableExtensions.IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
                where T : class
            {
                return DbExtensions.Include(source, path);
            }
        }    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Item>().HasRequired(m => m.OrderID)
            //            .WithRequiredPrincipal().Map(map => map.MapKey("OrderId").ToTable("Orders"));


            base.OnModelCreating(modelBuilder);
        }

        public static void CreateInitialDB() 
        {
            Database.SetInitializer<DomainContext>(new DBInitializer());        
        }
    }
}
