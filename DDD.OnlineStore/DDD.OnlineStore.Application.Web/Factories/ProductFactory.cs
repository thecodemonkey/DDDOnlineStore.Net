using DDD.OnlineStore.Application.Web.Models;       
using DDD.OnlineStore.Domain.Model;            
using DDD.OnlineStore.Domain.Repositories;  
using System;                           
using System.Collections.Generic;
using System.Linq;      
using System.Web;

namespace DDD.OnlineStore.Application.Web.Factories
{
    public class ProductFactory
    {
        public static IEnumerable<ProductModel> CreateProductModelList(IEnumerable<Product> products, CategoryRepository categoryRepository)
        {
            List<ProductModel> list = new List<ProductModel>();
            if (products != null)
            {
                foreach (Product product in products)
                {
                    list.Add(CreateProductModel(product, categoryRepository));
                }
            }

            return list.AsReadOnly();
        }

        public static ProductModel CreateProductModel(Product product, CategoryRepository categoryRepository)
        {                                                                               
            var availableCategories = categoryRepository.GetAll();  

            return new ProductModel
            {                   
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                AvailableCategories = CategoryFactory.CreateCategoryModels(availableCategories, product.Categories),
            };
        }

        public static Product CreateDomainProduct(ProductModel productModel)
        {
            var domainProduct = new Product
            {
                ID = productModel.ID,
                Name = productModel.Name,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                Categories = CategoryFactory.CreateDomainCategories(productModel.AssignedCategories).ToList()
            };

            return domainProduct;
        }
    }
}