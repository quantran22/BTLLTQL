using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLLTQL.Models;

namespace BTLLTQL.Areas.KhachHang.Controllers
{
    
    public class DanhGiasController : Controller
    {
        private DBContext db = new DBContext();

        // GET: KhachHang/DanhGias
        public ActionResult Index()
        {
            var danhGias = db.DanhGias.Include(d => d.khachhang).Include(d => d.SanPham);
            return View(danhGias.ToList());
        }

        // GET: KhachHang/DanhGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }
        [Authorize(Roles = "KH")]
        // GET: KhachHang/DanhGias/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.Khachhangs, "MaKH", "TenKhachHang");
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: KhachHang/DanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhGia,MaSanPham,MaKH,Ngay_Gio,NoiDung,Sđt")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                db.DanhGias.Add(danhGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.Khachhangs, "MaKH", "TenKhachHang", danhGia.MaKH);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", danhGia.MaSanPham);
            return View(danhGia);
        }
        [Authorize(Roles = "KH")]
        // GET: KhachHang/DanhGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.Khachhangs, "MaKH", "TenKhachHang", danhGia.MaKH);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", danhGia.MaSanPham);
            return View(danhGia);
        }

        // POST: KhachHang/DanhGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhGia,MaSanPham,MaKH,Ngay_Gio,NoiDung,Sđt")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.Khachhangs, "MaKH", "TenKhachHang", danhGia.MaKH);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", danhGia.MaSanPham);
            return View(danhGia);
        }
        [Authorize(Roles = "KH")]
        // GET: KhachHang/DanhGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // POST: KhachHang/DanhGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGia danhGia = db.DanhGias.Find(id);
            db.DanhGias.Remove(danhGia);
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
