using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Models.Common
{
    public class SelectionItem
    {
        public string Label { get; set; }
        public int ID { get; set; }
        public bool IsSelected { get; set; }
    }
}