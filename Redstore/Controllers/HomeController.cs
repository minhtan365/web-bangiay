using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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
        public ActionResult addSP(string idSP)
        {
            GioHang gioHang = Session["giohang"] as GioHang;
            if(gioHang == null)
            {
                gioHang = new GioHang();
                Session["Cart"] = gioHang;
            }
            gioHang.themItem(idSP);
            Session["Cart"] = gioHang;

            var response = new
            {
                success = true,
                message = "them item thanh cong",
                cartItemCount = gioHang.tongslSP(),
            };
            return Json(response);
        }
    }
}