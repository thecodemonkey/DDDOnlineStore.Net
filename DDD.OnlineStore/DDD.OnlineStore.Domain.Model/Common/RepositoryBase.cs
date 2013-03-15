using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Common
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private IRepository<TEntity> _repository;

        public RepositoryBase(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public TEntity GetByID(int id)
        {
            return this._repository.GetByID(id);
        }

        public IQueryable<TEntity> Queryable
        {
            get
            {
                return this._repository.Queryable;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._repository.GetAll();
        }

        public void Insert(TEntity entity)
        {
            this._repository.Insert(entity);
        }

        public void Update(TEntity entity) 
        {
            this._repository.Update(entity);
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public void Save()
        {
            this._repository.Save();
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

    }
}
