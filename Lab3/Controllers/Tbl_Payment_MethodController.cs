﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class Tbl_Payment_MethodController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        // GET: Tbl_Payment_Method
        public ActionResult Index()
        {
            return View(db.Tbl_Payment_Method.ToList());
        }

        // GET: Tbl_Payment_Method/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Payment_Method tbl_Payment_Method = db.Tbl_Payment_Method.Find(id);
            if (tbl_Payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment_Method);
        }

        // GET: Tbl_Payment_Method/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Payment_Method/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pa_ID,Pa_Method")] Tbl_Payment_Method tbl_Payment_Method)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Payment_Method.Add(tbl_Payment_Method);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Payment_Method);
        }

        // GET: Tbl_Payment_Method/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Payment_Method tbl_Payment_Method = db.Tbl_Payment_Method.Find(id);
            if (tbl_Payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment_Method);
        }

        // POST: Tbl_Payment_Method/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pa_ID,Pa_Method")] Tbl_Payment_Method tbl_Payment_Method)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Payment_Method).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Payment_Method);
        }

        // GET: Tbl_Payment_Method/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Payment_Method tbl_Payment_Method = db.Tbl_Payment_Method.Find(id);
            if (tbl_Payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment_Method);
        }

        // POST: Tbl_Payment_Method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Payment_Method tbl_Payment_Method = db.Tbl_Payment_Method.Find(id);
            db.Tbl_Payment_Method.Remove(tbl_Payment_Method);
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
