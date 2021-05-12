using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDiemSinhVien.Models;

namespace QuanLyDiemSinhVien.Controllers
{
    public class HeDaoTaosController : Controller
    {
        private QLDSVDbContext db = new QLDSVDbContext();

        // GET: HeDaoTaos
        public ActionResult Index()
        {
            return View(db.HeDaoTaos.ToList());
        }

        // GET: HeDaoTaos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // GET: HeDaoTaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeDaoTaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHeDaoTao,TenHeDaoTao")] HeDaoTao heDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.HeDaoTaos.Add(heDaoTao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heDaoTao);
        }

        // GET: HeDaoTaos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // POST: HeDaoTaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHeDaoTao,TenHeDaoTao")] HeDaoTao heDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heDaoTao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heDaoTao);
        }

        // GET: HeDaoTaos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // POST: HeDaoTaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            db.HeDaoTaos.Remove(heDaoTao);
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

