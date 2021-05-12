using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDiemSinhVien.Models;

namespace QuanLyDiemSinhVien.Controllers
{
    public class KhoaHocsController : Controller
    {
        private QLDSVDbContext db = new QLDSVDbContext();

        // GET: KhoaHocs
        public ActionResult Index()
        {
            return View(db.KhoaHocs.ToList());
        }

        // GET: KhoaHocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaHoc khoaHoc = db.KhoaHocs.Find(id);
            if (khoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoaHoc,TenKhoaHoc")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                db.KhoaHocs.Add(khoaHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoaHoc);
        }

        // GET: KhoaHocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaHoc khoaHoc = db.KhoaHocs.Find(id);
            if (khoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(khoaHoc);
        }

        // POST: KhoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoaHoc,TenKhoaHoc")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoaHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaHoc khoaHoc = db.KhoaHocs.Find(id);
            if (khoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(khoaHoc);
        }

        // POST: KhoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoaHoc khoaHoc = db.KhoaHocs.Find(id);
            db.KhoaHocs.Remove(khoaHoc);
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
