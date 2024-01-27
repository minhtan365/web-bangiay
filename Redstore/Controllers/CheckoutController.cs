using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redstore.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;

namespace Redstore.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpGet]
        public ActionResult Index()
        {
            Users users = new Users();
            GioHang gio = Session["giohang"] as GioHang;
            if (gio == null)
            {
                gio = new GioHang();
                Session["giohang"] = gio;
            }
            ViewData["Cart"] = gio;
            return View(users);
        }
        [HttpPost]
        public ActionResult SaveInFo(Users users)
        {
            using(var db = new RedStore1Entities5())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        users.idUser = users.idUser;
                        db.Users.Add(users);
                        db.SaveChanges();
                        Orders or = new Orders();
                        or.soDH = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                        or.idUser = users.idUser;
                        or.ngayDat = DateTime.Now;
                        or.ngayGiao = DateTime.Now.AddDays(2);
                        tkNguoiDung nguoiDung = new tkNguoiDung();
                        or.taiKhoan = nguoiDung.taiKhoan;
                        or.diaChiGH = users.Adress;
                        db.Orders.Add(or);
                        db.SaveChanges();
                        GioHang cart = Session["giohang"] as GioHang;
                        foreach(detailOrders detail in cart.SPchon.Values)
                        {
                            detail.soDH = or.soDH;
                            db.detailOrders.Add(detail);
                        }
                        db.SaveChanges();
                        Session.Remove("giohang");
                        transaction.Commit();
                        return RedirectToAction("Index", "Home");

                    }catch(Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return RedirectToAction("Index", "Checkout");
        }
    }
}