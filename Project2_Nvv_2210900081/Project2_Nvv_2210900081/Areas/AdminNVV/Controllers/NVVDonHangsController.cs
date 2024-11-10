using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2_Nvv_2210900081.Models;
using Project2_Nvv_2210900081.ModelView;

namespace Project2_Nvv_2210900081.Areas.AdminNVV.Controllers
{
    public class NVVDonHangsController : Controller
    {
        private NguyenVanVuK22CNT2Entities db = new NguyenVanVuK22CNT2Entities();

        // GET: AdminNVV/NVVDonHangs
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.KhachHang);
            return View(donHangs.ToList());
        }

        // GET: AdminNVV/NVVDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: AdminNVV/NVVDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.id_khach_hang = new SelectList(db.KhachHangs, "id", "ten");
            return View();
        }

        // POST: AdminNVV/NVVDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_khach_hang,ngay_dat,tong_tien")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_khach_hang = new SelectList(db.KhachHangs, "id", "ten", donHang.id_khach_hang);
            return View(donHang);
        }

        // GET: AdminNVV/NVVDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_khach_hang = new SelectList(db.KhachHangs, "id", "ten", donHang.id_khach_hang);
            //thông tin chi tiết đơn hàng
            var DonHangChiTiet = from ct in db.ChiTietDonHangs
                                 join sp in db.SanPhams on ct.id_san_pham equals sp.id
                                 where ct.id_don_hang == id
                                 select new DH_CT
                                 {
                                     Id = ct.id,
                                     Name = sp.ten,
                                     Image = sp.hinh_anh,
                                     
                                     Qty = ct.so_luong,
                                     
                                 };
            ViewBag.DonHangChiTiet= DonHangChiTiet;
           
            return View(donHang);
        }


        // POST: AdminNVV/NVVDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_khach_hang,ngay_dat,tong_tien")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                var DonHang = db.DonHangs.FirstOrDefaultAsync(x => x.id == donHang.id);
             if (DonHang == null)
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_khach_hang = new SelectList(db.KhachHangs, "id", "ten", donHang.id_khach_hang);
            return View(donHang);
        }

        // GET: AdminNVV/NVVDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: AdminNVV/NVVDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
