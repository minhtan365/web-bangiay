using Redstore.Areas.PrivatePages.Models;
using Redstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redstore.Areas.PrivatePages.Controllers
{
    public class OrderListController : Controller
    {
        private readonly RedStore1Entities5 db = new RedStore1Entities5();
        // GET: PrivatePages/OrderList
        [HttpGet]
        public ActionResult Index()
        {
            AdminAccounts amin = (AdminAccounts)Session["Admin"];
            if (amin == null)
            {
                Response.Redirect("~/PrivatePages/LoginAdmin/Index"); // Chuyển hướng đến trang đăng nhập
            }
            var ListOrderss = db.Set<Orders>().ToList();
             
            ViewData["DSDH"] = ListOrderss; 
            return View();
        }
        [HttpPost]
        public ActionResult CancelOrder(string soDH) 
        {
            Orders finOrder = db.Orders.Find(soDH);
            if (finOrder != null)
            {
                finOrder.tinhtrangDH = "Đã hủy";
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Activated(string soDHs) 
        {
            Orders orders = db.Orders.Find(soDHs);
            if (orders != null)
            {
                orders.tinhtrangDH = "Đang giao";
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Success(string soDHss)
        {
            Orders aorders = db.Orders.Find(soDHss);
            if (aorders != null)
            {
                aorders.tinhtrangDH = "Đã Giao";
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}