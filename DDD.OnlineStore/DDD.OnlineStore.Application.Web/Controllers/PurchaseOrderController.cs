using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class PurchaseOrderController : ControllerBase
    {
        private PurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderController(PurchaseOrderRepository purchaseOrderRepository)
        {
            this._purchaseOrderRepository = purchaseOrderRepository;
        }

        public ActionResult Index()
        {
            var purchaseOrders = this._purchaseOrderRepository.GetOrdersByUserID(this.User.UserID);

            return View(purchaseOrders);
        }
    }
}