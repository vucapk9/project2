using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_Nvv_2210900081.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Xử lý logic đăng nhập tại đây (ví dụ: kiểm tra username và password trong cơ sở dữ liệu)
            // Nếu thành công, lưu thông tin người dùng vào session và chuyển hướng

            // Nếu đăng nhập thành công
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }
       

    }
    }

