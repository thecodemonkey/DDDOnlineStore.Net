using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IIncluder Includer = new NullIncluder();

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return Includer.Include(source, path);
        }

        public interface IIncluder
        {
            IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class;
        }

        internal class NullIncluder : IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
            {
                return source;
            }
        }
    }
}
