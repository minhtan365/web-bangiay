using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            GioHang gioHang = Session["giohang"] as GioHang;
            if(gioHang == null)
            {
                gioHang = new GioHang();
                Session["Cart"] = gioHang;
            }
            ViewData["Cart"] = gioHang;
            return View();
        }
        [HttpPost]
        public ActionResult addSP(string idSP)
        {
            GioHang gioHang = Session["giohang"] as GioHang;

            if (gioHang == null)
            {
                gioHang = new GioHang();
                Session["Cart"] = gioHang;
            }

            gioHang.themItem(idSP);
            Session["Cart"] = gioHang;

            var response = new
            {
                success = true,
                message = "Item added to the cart successfully.",
                cartItemCount = gioHang.tongslSP(),
            };

            if (Request.IsAjaxRequest())
            {
                return Json(response);
            }
            string referrerUrl = Request.UrlReferrer?.AbsolutePath;

            if (string.Equals(referrerUrl, "/Products/Index", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Index", "Products");
            }

            return Redirect(referrerUrl ?? "~/");
        }

    }
}