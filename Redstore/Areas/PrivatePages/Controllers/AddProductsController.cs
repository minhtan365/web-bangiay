using Redstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redstore.Areas.PrivatePages.Controllers
{
    public class AddProductsController : Controller
    {
        private readonly RedStore1Entities5 db = new RedStore1Entities5();
        // GET: PrivatePages/AddProducts
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
        public ActionResult Index(Products product)
        {
            HttpPostedFileBase file = Request.Files["file"];

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    file.SaveAs(path);

                    product.imgSP = "/Images/" + fileName;
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

    }
}