using DDD.OnlineStore.Application.Web.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public SelectionItem[] AvailableCategories { get; set; }

        public IEnumerable<SelectionItem> AssignedCategories
        {
            get
            {
                return this.AvailableCategories.Where(r => r.IsSelected);
            }
        }
    }
}