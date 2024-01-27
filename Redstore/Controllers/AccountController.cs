using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
namespace Redstore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
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
        [ValidateAntiForgeryToken]
        public ActionResult Resigter(tkNguoiDung nguoiDung)
        {
            RedStore1Entities5 redStore = new RedStore1Entities5();
            {
                if (nguoiDung.passWords.Equals(nguoiDung.passWords))
                {
                    redStore.tkNguoiDung.Add(nguoiDung);
                    redStore.SaveChanges();
                    if (ModelState.IsValid)
                        ModelState.Clear();
                }
                return RedirectToAction("Index", "Account", new { are = "Views" });
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("nguoidung");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TaiKhoan taiKhoan)
        {
            
            
            tkNguoiDung nguoiDung = taiKhoan.ttNguoiDung();

            bool Authentic = nguoiDung != null && nguoiDung.taiKhoan.Equals(taiKhoan.Account.ToLower().Trim()) && nguoiDung.passWords.Equals(taiKhoan.Password);
            if (Authentic)
            {
                Session["nguoidung"] = nguoiDung.taiKhoan;
                Session["infologin"] = nguoiDung;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}