using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Configuration
{
    public class DBConfiguration : DbMigrationsConfiguration<DomainContext>
    {
        public DBConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
