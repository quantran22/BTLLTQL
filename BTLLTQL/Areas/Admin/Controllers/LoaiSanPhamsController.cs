﻿using System;
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
    public class LoaiSanPhamsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/LoaiSanPhams
        public ActionResult Index()
        {
            return View(db.LoaiSanPhams.ToList());
        }

        // GET: Admin/LoaiSanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }
        // GET: Admin/LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSanPham,TenLoaiSanPham")] LoaiSanPham loaiSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LoaiSanPhams.Add(loaiSanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

               
            }
            catch
            {
                ModelState.AddModelError("", "Mã loại Sản phẩm đã tồn tại");
            }
            return View(loaiSanPham);
        }
           

        // GET: Admin/LoaiSanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSanPham,TenLoaiSanPham")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            db.LoaiSanPhams.Remove(loaiSanPham);
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
