using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
      where TEntity : class, IEntity 
    {
        private bool isDisposed = false;
        private EFDomainContext _context;

        public GenericRepository(EFDomainContext context)
        {
            this._context = context;
        }

        public TEntity GetByID(int id)
        {
            return this.Queryable.Where(t => t.ID == id).FirstOrDefault();
        }

        public void Insert(TEntity account)
        {
            this._context.Set<TEntity>().Add(account);
        }

        public void Update(TEntity entity)
        {
            this._context.Set<TEntity>().Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;

            //catch (DbUpdateConcurrencyException e)
            //{
            //    var entry = e.Entries.Single();
            //    var databaseValues = (TEntity)entry.GetDatabaseValues().ToObject();
            //    var clientValues = (TEntity)entry.Entity;

            //    throw new UpdateConcurrencyException<TEntity>(clientValues, databaseValues);
            //}        
        }

        public void Delete(int id)
        {
            var saved = this._context.Set<TEntity>().Find(id);
            this._context.Set<TEntity>().Remove(saved);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>().ToArray();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Queryable
        {
            get { return this._context.Set<TEntity>().AsQueryable(); }
        }
    }
}
