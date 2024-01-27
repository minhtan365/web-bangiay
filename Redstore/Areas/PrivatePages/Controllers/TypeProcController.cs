using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Controllers
{
    public class TypeProcController : Controller
    {
        private static bool isUpdate = false;
        // GET: PrivatePages/NewArticle
        [HttpGet]
        public ActionResult Index()
        {
            AdminAccounts amin = (AdminAccounts)Session["Admin"];
            if (amin == null)
            {
                Response.Redirect("~/PrivatePages/LoginAdmin/Index"); // Chuyển hướng đến trang đăng nhập
            }
            List<typProducts> typProducts = new RedStore1Entities5().typProducts.OrderBy(z => z.secTors).ToList<typProducts>();
            ViewData["DSLoai"] = typProducts;
            return View();
        }
        [HttpPost]
        public ActionResult Index(typProducts x)
        {
            RedStore1Entities5 db = new RedStore1Entities5();
            if (!isUpdate)
            {
                db.typProducts.Add(x);
            }
            else
            {
                typProducts y = db.typProducts.Find(x.typeSP);
                y.typeSP = x.typeSP;
                y.secTors = x.secTors;
                y.noTe = x.noTe;
                isUpdate = false;
            }
            
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            List<typProducts> l = db.typProducts.OrderBy(z => z.secTors).ToList<typProducts>();
            ViewData["DSLoai"] = l;
            return View("Index");
        }
        [HttpPost]
        public ActionResult Remove(string maLoai)
        {
            RedStore1Entities5 db = new RedStore1Entities5();
            int findma = int.Parse(maLoai);
            typProducts x = db.typProducts.Find(findma);
            db.typProducts.Remove(x);
            db.SaveChanges();
            List<typProducts> l = db.typProducts.OrderBy(z => z.secTors).ToList<typProducts>();
            ViewData["DSLoai"] = l;
            return View("Index");
        }
        [HttpPost]
        public ActionResult Update(string maLoaic)
        {
            RedStore1Entities5 db = new RedStore1Entities5();
            int findma = int.Parse(maLoaic);
            typProducts x = db.typProducts.Find(findma);
            isUpdate = true;
            List<typProducts> l = db.typProducts.OrderBy(z => z.secTors).ToList<typProducts>();
            ViewData["DSLoai"] = l;
            return View("Index",x);
        }
    }
}