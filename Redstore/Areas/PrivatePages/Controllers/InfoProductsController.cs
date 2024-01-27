using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Controllers
{
    public class InfoProductsController : Controller
    {
        private readonly RedStore1Entities5 entities = new RedStore1Entities5();

        // GET: PrivatePages/InfoProducts
        [HttpGet]
        public ActionResult Index(string idSP)
        {
            AdminAccounts amin = (AdminAccounts)Session["Admin"];
            if (amin == null)
            {
                Response.Redirect("~/PrivatePages/LoginAdmin/Index"); // Chuyển hướng đến trang đăng nhập
            }
            Products products = entities.Products.Find(idSP);
            return View(products);
        }
        [HttpPost]
        public ActionResult Savetodata(string idSP, Products updateProduct)
        {
            Products finIdProc = entities.Products.Find(idSP);
            if(finIdProc != null)
            {
                finIdProc.nameSP = updateProduct.nameSP;
                finIdProc.noiDungSP=updateProduct.noiDungSP;
                finIdProc.priceSP= updateProduct.priceSP;
                entities.Entry(finIdProc).State = EntityState.Modified;
                entities.SaveChanges();
            }
            return RedirectToAction("Index", "ProductList");
        }
    }
}