using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common;
using DDD.OnlineStore.Domain.Model;                      
using System;                                     
using System.Collections.Generic;            
using System.Data.Entity.Infrastructure;
using System.Linq;                   
using System.Text;              
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Repositories
{
    public class EFProductRepository : EFGenericRepository<Product>
    {
        public EFProductRepository(EFDomainContext context) : base(context) { }

        public override void Insert(Product product)
        {
            if (product.Categories != null)
            {
                foreach (Category category in product.Categories)
                {
                    this.DBContext.Set<Category>().Attach(category);
                }
            }

            base.Insert(product);
        }

        public override void Update(Product product)
        {
            //get current product from db                      
            var productFromDB = this.Queryable.Where(u => u.ID == product.ID)
                                            .Include(u => u.Categories).FirstOrDefault();

            //remove roles
            productFromDB.Categories.Clear();

            //add roles
            foreach (var role in product.Categories)
            {
                if (!productFromDB.Categories.Any(r => r.ID == role.ID))
                {
                    var newCategory = new Category { ID = role.ID };

                    Category existingCategory = this.DBContext.GetExistingEntity(newCategory, "CategorySet");

                    if (existingCategory == null)
                    {
                        this.DBContext.CategorySet.Attach(newCategory);
                        productFromDB.Categories.Add(newCategory);
                    }
                    else
                    {
                        productFromDB.Categories.Add(existingCategory);
                    }
                }
            }

            //copies all entity values
            this.DBContext.Entry(productFromDB).CurrentValues.SetValues(product);

            base.Update(productFromDB);
        }
    }
}
