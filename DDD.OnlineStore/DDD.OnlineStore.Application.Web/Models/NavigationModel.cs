using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Models
{
    public class NavigationModel
    {
        public NavigationModel() 
        {
            this.Items = new List<NavigationItem>{
                new NavigationItem("Einkaufen", "Index", "Home", true),
                new NavigationItem("Produktverwaltung", "Index", "Product"),
                new NavigationItem("Benutzerverwaltung", "Index", "User"),
                new NavigationItem("Rollen", "Index", "Role"),
                new NavigationItem("Produktkategorien", "Index", "Category"),
                new NavigationItem("Warenkorb", "Index", "ShoppingCart"),
                new NavigationItem("Meine Bestellungen", "Index", "PurchaseOrder"),
                new NavigationItem("Logout", "Logout", "Authentication")     
            };
        }

        public List<NavigationItem> Items { get; set; }

        public NavigationItem GetItem(string action, string controller) 
        {
            return this.Items.FirstOrDefault(i => i.Action == action && i.Controller == controller);
        }

        public void SelectItem(NavigationItem item) 
        {
            foreach (NavigationItem ni in this.Items) 
            {
                if (ni == item)
                    ni.IsSelected = true;
                else
                    ni.IsSelected = false;
            }
        }
    }

    public class NavigationItem 
    {
        public NavigationItem(string label, string action, string controller) : this(label, action, controller, false){ }

        public NavigationItem(string label, string action, string controller, bool selected) 
        {
            this.Label = label;
            this.Controller = controller;
            this.Action = action;
            this.IsSelected = selected;
        }

        public string Label { get; private set; }
        public string Controller { get; private set; }
        public string Action { get; private set; }
        public bool IsSelected { get; set; }
    }
}