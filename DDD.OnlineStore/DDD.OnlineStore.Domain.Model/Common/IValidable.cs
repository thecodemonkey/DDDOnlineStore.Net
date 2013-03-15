using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Common
{
    public interface IValidable
    {
        //void Validate();
        bool IsValid{get;}
    }
}
