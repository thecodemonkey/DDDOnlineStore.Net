using Microsoft.Practices.ObjectBuilder2;               
using Microsoft.Practices.Unity;            
using System;                       
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Common
{
    public class UnityConstructorParameterResolver : ResolverOverride
    {
        private readonly Queue<InjectionParameterValue> parameterValues;

        public UnityConstructorParameterResolver(params object[] parameters)
        {
            this.parameterValues = new Queue<InjectionParameterValue>();
            foreach (var value in parameters)
            {
                this.parameterValues.Enqueue(InjectionParameterValue.ToParameter(value));
            }
        }
 
        public override IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
        {
            if (parameterValues.Count < 1)
                return null;
 
            var value = this.parameterValues.Dequeue();
            return value.GetResolverPolicy(dependencyType);
        }
    }
}