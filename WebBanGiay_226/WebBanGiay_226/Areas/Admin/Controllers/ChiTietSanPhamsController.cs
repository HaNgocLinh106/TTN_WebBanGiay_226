using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Areas.Admin.Controllers
{
    public class ChiTietSanPhamsController : Controller
    {
        private WebGiay db = new WebGiay();

        // GET: Admin/ChiTietSanPhams
        public ActionResult Index()
        {
            var chiTietSanPhams = db.ChiTietSanPhams.Include(c => c.SanPham);
            return View(chiTietSanPhams.ToList());
        }

        // GET: Admin/ChiTietSanPhams/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }

        // GET: Admin/ChiTietSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: Admin/ChiTietSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTSP,MetaTitle,Code,Mau,Size,SoLuong,LinkAnh,TrangThai,MaSanPham")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSanPhams.Add(chiTietSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietSanPham.MaSanPham);
            return View(chiTietSanPham);
        }

        // GET: Admin/ChiTietSanPhams/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietSanPham.MaSanPham);
            return View(chiTietSanPham);
        }

        // POST: Admin/ChiTietSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTSP,MetaTitle,Code,Mau,Size,SoLuong,LinkAnh,TrangThai,MaSanPham")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietSanPham.MaSanPham);
            return View(chiTietSanPham);
        }

        // GET: Admin/ChiTietSanPhams/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }

        // POST: Admin/ChiTietSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            db.ChiTietSanPhams.Remove(chiTietSanPham);
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
