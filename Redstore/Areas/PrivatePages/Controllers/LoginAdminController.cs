using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Areas.PrivatePages.Models;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: PrivatePages/LoginAdmin
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TaiKhoanAdmin accounts)
        {
            AdminAccounts admin = accounts.ttAdmin();
            bool authentic = admin != null && admin.taiKhoanAdmin.Equals(accounts.taiKhoanAdmin.ToLower().Trim()) && admin.matKhauAdmin.Equals(accounts.matKhauAdmin);
            if (authentic)
            {
                Session["NameAdmin"] = admin.taiKhoanAdmin;
                Session["Admin"] = admin;
                return RedirectToAction("Index","QTri");
            }
            return View();
        }
    }
}