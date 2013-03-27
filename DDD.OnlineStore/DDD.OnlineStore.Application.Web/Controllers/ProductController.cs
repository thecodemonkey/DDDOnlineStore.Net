using DDD.OnlineStore.Application.Web.Factories;
using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;                      
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class ProductController : EditorControllerBase<Product, ProductRepository>
    {
        private CategoryRepository _categoryRepository;

        public ProductController(ProductRepository productRepository, CategoryRepository categoryRepository)
            : base(productRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public override ActionResult Index()
        {                                       
            var domainProducts = this.Repository.GetAll();
            var viewModelProducts = ProductFactory.CreateProductModelList(domainProducts, this._categoryRepository);
            
            return View(viewModelProducts);
        }

        public ActionResult CreateProduct()
        {
            var viewModelProduct = new ProductModel();
            var availableCategories = this._categoryRepository.GetAll();

            viewModelProduct.AvailableCategories = CategoryFactory.CreateCategoryModels(availableCategories, null);

            return View("Edit", viewModelProduct);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel productModel) 
        { 
            var domainProduct = ProductFactory.CreateDomainProduct(productModel);
            return base.Create(domainProduct);
        }

        public ActionResult EditProduct(int id)
        {                                           
            var domainProduct = this.Repository.GetByID(id);
            var viewModelProduct = ProductFactory.CreateProductModel(domainProduct, this._categoryRepository);
            
            return View("Edit", viewModelProduct);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel productModel)
        {
            var domainProduct = ProductFactory.CreateDomainProduct(productModel);
            return base.Edit(domainProduct);
        }

    }
}
