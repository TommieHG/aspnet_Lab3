using System;
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
    public class Tbl_OrderController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        // GET: Tbl_Order
        //public ActionResult Index()
        //{
        //    var tbl_Order = db.Tbl_Order.Include(t => t.Tbl_Customer);
        //    return View(tbl_Order.ToList());
        //}

        public ActionResult Index(string filterCity)
        {
            ViewBag.filter = (from s in db.Tbl_Order select s.Or_ToCity).Distinct();

            var filter = from r in db.Tbl_Order
                         orderby r.Or_ToName
                         where r.Or_ToCity == filterCity || filterCity == null || filterCity == ""
                         select r;

            return View(filter.ToList());

        }

        // GET: Tbl_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Order tbl_Order = db.Tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order);
        }

        // GET: Tbl_Order/Create
        public ActionResult Create()
        {
            ViewBag.Or_Cu_ID = new SelectList(db.Tbl_Customer, "Cu_ID", "Cu_FirstName");
            return View();
        }

        // POST: Tbl_Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Or_ID,Or_Cu_ID,Or_ToName,Or_ToStreet,Or_ToZipCode,Or_ToCity,Or_OrderTime")] Tbl_Order tbl_Order)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Order.Add(tbl_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Or_Cu_ID = new SelectList(db.Tbl_Customer, "Cu_ID", "Cu_FirstName", tbl_Order.Or_Cu_ID);
            return View(tbl_Order);
        }

        // GET: Tbl_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Order tbl_Order = db.Tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Or_Cu_ID = new SelectList(db.Tbl_Customer, "Cu_ID", "Cu_FirstName", tbl_Order.Or_Cu_ID);
            return View(tbl_Order);
        }

        // POST: Tbl_Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Or_ID,Or_Cu_ID,Or_ToName,Or_ToStreet,Or_ToZipCode,Or_ToCity,Or_OrderTime")] Tbl_Order tbl_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Or_Cu_ID = new SelectList(db.Tbl_Customer, "Cu_ID", "Cu_FirstName", tbl_Order.Or_Cu_ID);
            return View(tbl_Order);
        }

        // GET: Tbl_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Order tbl_Order = db.Tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order);
        }

        // POST: Tbl_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Order tbl_Order = db.Tbl_Order.Find(id);
            db.Tbl_Order.Remove(tbl_Order);
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
