using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository) 
        {
            this._productRepository = productRepository;
        }

        public ActionResult Index()
        {
            var products = this._productRepository.GetAll();

            return View(products);
        }

        public ActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                this._productRepository.Add(product);
                this._productRepository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View("Edit", product);
            }
        }

        public ActionResult Edit(int id)
        {
            var product = this._productRepository.GetByID(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                this._productRepository.Add(product);
                this._productRepository.Save();

                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                this.ModelState.AddModelError("", exp.Message);
                return View(product);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this._productRepository.Delete(id);
                this._productRepository.Save();

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
