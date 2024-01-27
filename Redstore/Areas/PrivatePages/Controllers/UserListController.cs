using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Controllers
{
    public class UserListController : Controller
    {
        // GET: PrivatePages/UserList
        [HttpGet]
        public ActionResult Index()
        {
            AdminAccounts amin = (AdminAccounts)Session["Admin"];
            if (amin == null)
            {
                Response.Redirect("~/PrivatePages/LoginAdmin/Index"); // Chuyển hướng đến trang đăng nhập
            }
            RedStore1Entities5 db = new RedStore1Entities5();
            var ListUser = db.Set<Users>().ToList();
            ViewData["users"] = ListUser;
            return View();
        }
    }
}