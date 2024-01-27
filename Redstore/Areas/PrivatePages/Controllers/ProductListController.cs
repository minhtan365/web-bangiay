using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Areas.PrivatePages.Models;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Controllers
{
    public class ProductListController : Controller
    {
        RedStore1Entities5 db = new RedStore1Entities5();
        // GET: PrivatePages/NewProducts
        [HttpGet]
        public ActionResult Index()
        {
            AdminAccounts amin = (AdminAccounts)Session["Admin"];
            if (amin == null)
            {
                Response.Redirect("~/PrivatePages/LoginAdmin/Index"); // Chuyển hướng đến trang đăng nhập
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string idSP)
        {
            Products x = db.Products.Find(idSP);
            db.Products.Remove(x);
            db.SaveChanges();
            List<Products> list = db.Products.OrderBy(z=>z.nameSP).ToList<Products>();
            ViewData["DSsanpham"]=list;
            return RedirectToAction("Index","ProductList");
        }
        [HttpPost]
        public ActionResult Info(string idSPs)
        {
            Products products = db.Products.Find(idSPs);
            List<Products> ds = db.Products.OrderBy(z => z.nameSP).ToList();
            ViewData["InFo"] = ds;
            return RedirectToAction("Index", "InfoProducts", products);
        }

    }
}