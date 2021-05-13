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
    [Authorize(Roles = "sinhvien02")]
    public class LopsController : Controller
    {
        private QLDSVDbContext db = new QLDSVDbContext();

        // GET: Lops
        [AllowAnonymous]
        public ActionResult Index()
        {
            var lops = db.Lops.Include(l => l.HeDaoTaos).Include(l => l.KhoaHocs).Include(l => l.Khoas);
            return View(lops.ToList());
        }

        // GET: Lops/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: Lops/Create
        public ActionResult Create()
        {
            ViewBag.MaHeDaoTao = new SelectList(db.HeDaoTaos, "MaHeDaoTao", "TenHeDaoTao");
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc");
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: Lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,TenLop,MaKhoa,MaHeDaoTao,MaKhoaHoc")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lops.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHeDaoTao = new SelectList(db.HeDaoTaos, "MaHeDaoTao", "TenHeDaoTao", lop.MaHeDaoTao);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", lop.MaKhoaHoc);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", lop.MaKhoa);
            return View(lop);
        }

        // GET: Lops/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHeDaoTao = new SelectList(db.HeDaoTaos, "MaHeDaoTao", "TenHeDaoTao", lop.MaHeDaoTao);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", lop.MaKhoaHoc);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", lop.MaKhoa);
            return View(lop);
        }

        // POST: Lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,MaKhoa,MaHeDaoTao,MaKhoaHoc")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHeDaoTao = new SelectList(db.HeDaoTaos, "MaHeDaoTao", "TenHeDaoTao", lop.MaHeDaoTao);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", lop.MaKhoaHoc);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", lop.MaKhoa);
            return View(lop);
        }

        // GET: Lops/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lop lop = db.Lops.Find(id);
            db.Lops.Remove(lop);
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
