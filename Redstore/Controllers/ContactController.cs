using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
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
    }
}