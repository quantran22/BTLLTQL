using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLLTQL.Models;

namespace BTLLTQL.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.TenLoaiSanPham = new SelectList(db.LoaiSanPhams, "TenLoaiSanPham", "MaLoaiSanPham");
            ViewBag.TenNhaSanXuat = new SelectList(db.NhaSanXuats, "TenNhaSanXuat", "MaNhaSanXuat");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenLoaiSanPham,TenNhaSanXuat,TenSanPham,CauHinh,HinhChinh,Gia,SoLuongBan,GioiThieu")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenLoaiSanPham = new SelectList(db.LoaiSanPhams, "TenLoaiSanPham", "MaLoaiSanPham", sanPham.TenLoaiSanPham);
            ViewBag.TenNhaSanXuat = new SelectList(db.NhaSanXuats, "TenNhaSanXuat", "MaNhaSanXuat", sanPham.TenNhaSanXuat);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenLoaiSanPham = new SelectList(db.LoaiSanPhams, "TenLoaiSanPham", "MaLoaiSanPham", sanPham.TenLoaiSanPham);
            ViewBag.TenNhaSanXuat = new SelectList(db.NhaSanXuats, "TenNhaSanXuat", "MaNhaSanXuat", sanPham.TenNhaSanXuat);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenLoaiSanPham,TenNhaSanXuat,TenSanPham,CauHinh,HinhChinh,Gia,SoLuongBan,TinhTrang")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenLoaiSanPham = new SelectList(db.LoaiSanPhams, "TenLoaiSanPham", "MaLoaiSanPham", sanPham.TenLoaiSanPham);
            ViewBag.TenNhaSanXuat = new SelectList(db.NhaSanXuats, "TenNhaSanXuat", "MaNhaSanXuat", sanPham.TenNhaSanXuat);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
