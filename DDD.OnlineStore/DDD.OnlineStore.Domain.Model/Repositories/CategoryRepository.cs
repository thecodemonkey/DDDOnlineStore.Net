using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(IRepository<Category> repository) : base(repository) { }
    }
}
