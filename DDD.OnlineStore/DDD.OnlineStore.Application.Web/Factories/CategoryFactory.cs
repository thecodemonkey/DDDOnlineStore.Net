using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Application.Web.Models.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Factories
{
    public class CategoryFactory
    {
        public static SelectionItem[] CreateCategoryModels(IEnumerable<Category> availableCategories, IEnumerable<Category> categoriesAssignedToUser)
        {                                                                           
            List<SelectionItem> result = new List<SelectionItem>(); 

            foreach (var category in availableCategories)
            {                                                       
                bool isAssigned = (categoriesAssignedToUser != null && categoriesAssignedToUser.Any(r => r.ID == category.ID));
                result.Add(new SelectionItem { Label = category.Name, ID = category.ID, IsSelected = isAssigned });
            }

            return result.ToArray();
        }

        public static IEnumerable<Category> CreateDomainCategories(IEnumerable<SelectionItem> selectedItems)
        {                                                               
            List<Category> result = new List<Category>();   

            if (selectedItems != null)
            {
                foreach (var item in selectedItems)
                {
                    if (item.IsSelected)
                    {
                        var r = new Category { Name = item.Label, ID = item.ID };
                        result.Add(r);
                    }
                }
            }

            return result;
        }
    }
}