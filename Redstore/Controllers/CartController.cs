using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            GioHang gio = Session["giohang"] as GioHang;
            if (gio == null)
            {
                gio = new GioHang();
                Session["giohang"] = gio;
            }
            ViewData["Cart"] = gio;
            return View();
        }
        [HttpPost]
         public ActionResult Tang(string idSP)
        {
            GioHang hang = Session["giohang"] as GioHang;
            hang.themItem(idSP);
            ViewData["Cart"] = hang;
            return RedirectToAction("Index");
        }
        public ActionResult Giam(string idSP)
        {
            GioHang hang = Session["giohang"] as GioHang;
            hang.giamSP(idSP);
            ViewData["Cart"] = hang;
            return RedirectToAction("Index");
        }
        public ActionResult XoaSP(string idSP)
        {
            GioHang hang = Session["giohang"] as GioHang;
            hang.xoaItem(idSP);
            ViewData["Cart"] = hang;
            return RedirectToAction("Index");
        }
             
        
    }
}