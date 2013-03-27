using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public abstract class EditorControllerBase<TEntity, TRepository> : ControllerBase
        where TEntity : IEntity
        where TRepository : IRepository<TEntity>
    {
        private TRepository _repository;

        public EditorControllerBase(TRepository repository) 
        {
            this._repository = repository;
        }

        protected TRepository Repository 
        {
            get
            {
                return this._repository;
            }
        }

        public virtual ActionResult Index()
        {
            return View(this._repository.GetAll());
        }

        public virtual ActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public virtual ActionResult Create(TEntity entity)
        {
            try
            {
                this._repository.Insert(entity);
                this._repository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View("Edit", entity);
            }
        }

        public virtual ActionResult Edit(int id)
        {
            return View(this._repository.GetByID(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(TEntity entity)
        {
            try
            {
                this._repository.Update(entity);
                this._repository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View("Edit", entity);
            }
        }

        //[HttpPost]
        public virtual ActionResult Delete(int id)
        {
            try
            {
                this._repository.Delete(id);
                this._repository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View("Index");
            }
        }
    }
}