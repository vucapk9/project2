using Project2_Nvv_2210900081.Buildness;
using Project2_Nvv_2210900081.Models;
using Project2_Nvv_2210900081.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_Nvv_2210900081.Controllers
{
    public class CartController : Controller
    {
        private NguyenVanVuK22CNT2Entities db = new NguyenVanVuK22CNT2Entities();
        private const string CartSessionKey = "Shoppingcart";
        // Lấy giỏ hàng từ session
        private Shoppingcart GetCart()
        {
            var cart = Session[CartSessionKey] as Shoppingcart;
            if (cart == null)
            {
                cart = new Shoppingcart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int Id, string name, string image, float price, int qty=1)
        {
            var cart = GetCart();
            var item = new CartItem
            {
                Id = Id,
                Name = name,
                Image = image,
                Price = price,
                Qty = qty,
                Total = price*qty
            };
            cart.AddToCart(item);
            return RedirectToAction("Index");

          
        }
        public ActionResult UpdateToCart(int Id, int qty)
        {
            var cart = GetCart();

            cart.UpdateToCart(Id, qty);
            return RedirectToAction("Index");
        }
        // GET: Cart
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        //thông tin thanh toán 
        public ActionResult ThongTinThanhToan()
        {
        var cart = GetCart();
        return View(cart); 
        }
        public ActionResult ThanhToan(FormCollection form)
        {
            // Lấy thông tin khách hàng từ form
            var ten_nguoi_nhan = form["KhachHang"];
            var dia_chi_nguoi_nhan = form["Dia_Chi_Nhan"];
            var dien_thoai_nguoi_nhan = form["Dien_Thoai_Nhan"];

            // Tạo đối tượng đơn hàng mới
            DonHang don_Hang = new DonHang();

            // Lấy ngày giờ hiện tại
            DateTime dt = DateTime.Now;

            // Cập nhật thông tin đơn hàng
            // don_Hang.m = "DH" + dt.ToString("yyyyMMddHHmmss"); // Mã đơn hàng duy nhất dựa trên thời gian
            //don_Hang.KhachHang = ten_nguoi_nhan;
            //don_Hang. = dia_chi_nguoi_nhan;
            //don_Hang.DienThoaiNhan = dien_thoai_nguoi_nhan;
            //don_Hang.NgayDat = dt;
            //don_Hang.TrangThai = 0;
            don_Hang.ngay_dat = dt;
            db.DonHangs.Add(don_Hang);
            db.SaveChanges();

            //lấy mã đơn hàng mới nhất
            int maxID_DH = db.DonHangs.Max(x => x.id);
            var cart = GetCart();
            foreach ( CartItem item in cart.Items )
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.id_don_hang = maxID_DH;
                ct.id_san_pham= maxID_DH;
                ct.so_luong = item.Qty;
                ct.gia = item.Qty;
                

            }
            return Redirect("/");
        }
    }
}