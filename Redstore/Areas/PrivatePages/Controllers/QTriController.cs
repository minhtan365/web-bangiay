using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Controllers
{
    public class QTriController : Controller
    {
        // GET: PrivatePages/QTri
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
    }
}