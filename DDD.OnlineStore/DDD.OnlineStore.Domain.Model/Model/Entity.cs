using DDD.OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public abstract class Entity : IEntity
    {
        public int ID { get; set; }
    }
}
