using Project2_Nvv_2210900081.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project2_Nvv_2210900081.Controllers
{
    public class AccountController : Controller
    {
        private NguyenVanVuK22CNT2Entities db = new NguyenVanVuK22CNT2Entities();
        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // Hiển thị trang đăng ký
        public ActionResult DangKy()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã tồn tại chưa
                var existingCustomer = db.KhachHangs.FirstOrDefault(kh => kh.email == khachHang.email);
                if (existingCustomer != null)
                {
                    ViewBag.Error = "Email này đã được đăng ký.";
                    return View(khachHang);
                }

                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            return View(khachHang);
        }

        // Hiển thị trang đăng nhập
        public ActionResult DangNhap()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string email, string sdt)
        {
            var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.email == email && kh.sdt == sdt);
            if (khachHang != null)
            {
                // Lưu thông tin khách hàng vào session sau khi đăng nhập thành công
                Session["KhachHangID"] = khachHang.id;
                Session["KhachHangTen"] = khachHang.ten;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Thông tin đăng nhập không chính xác.";
            return View();
        }

        // Đăng xuất
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}

