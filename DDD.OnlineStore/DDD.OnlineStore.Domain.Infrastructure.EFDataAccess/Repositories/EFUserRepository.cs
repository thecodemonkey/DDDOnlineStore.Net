using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Repositories
{
    public class EFUserRepository : EFGenericRepository<User>
    {
        public EFUserRepository(EFDomainContext context): base(context){}

        public override void Insert(User user)
        {
            if (user.Roles != null)
            {
                foreach (Role role in user.Roles)
                {
                    this.DBContext.Set<Role>().Attach(role);
                }
            }

            base.Insert(user);
        }

        public override void Update(User user)
        {                                           
            //get current user from db                      
            var userFromDB = this.Queryable.Where(u => u.ID == user.ID)
                                            .Include(u => u.Roles).FirstOrDefault();

            //remove roles
            userFromDB.Roles.Clear();

            //add roles
            foreach (var role in user.Roles) 
            {
                if (!userFromDB.Roles.Any(r => r.ID == role.ID))
                {
                    var newRole = new Role { ID = role.ID };
                    Role existingRole = this.DBContext.GetExistingEntity(newRole, "RoleSet");

                    if (existingRole == null)
                    {
                        this.DBContext.RoleSet.Attach(newRole);
                        userFromDB.Roles.Add(newRole);
                    }
                    else 
                    {
                        userFromDB.Roles.Add(existingRole);
                    }
                }    
            }

            //copies all entity values
            this.DBContext.Entry(userFromDB).CurrentValues.SetValues(user);

            base.Update(userFromDB); 
        }
    }
}
