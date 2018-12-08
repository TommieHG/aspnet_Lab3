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
    public class Tbl_Order_ProductController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        // GET: Tbl_Order_Product
        public ActionResult Index()
        {
            var tbl_Order_Product = db.Tbl_Order_Product.Include(t => t.Tbl_Order).Include(t => t.Tbl_Product);
            return View(tbl_Order_Product.ToList());
        }

        // GET: Tbl_Order_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Order_Product tbl_Order_Product = db.Tbl_Order_Product.Find(id);
            if (tbl_Order_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order_Product);
        }

        // GET: Tbl_Order_Product/Create
        public ActionResult Create()
        {
            ViewBag.OrderOr_ID = new SelectList(db.Tbl_Order, "Or_ID", "Or_ToName");
            ViewBag.ProductPr_ID = new SelectList(db.Tbl_Product, "Pr_ID", "Pr_Name");
            return View();
        }

        // POST: Tbl_Order_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderOr_ID,ProductPr_ID")] Tbl_Order_Product tbl_Order_Product)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Order_Product.Add(tbl_Order_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderOr_ID = new SelectList(db.Tbl_Order, "Or_ID", "Or_ToName", tbl_Order_Product.OrderOr_ID);
            ViewBag.ProductPr_ID = new SelectList(db.Tbl_Product, "Pr_ID", "Pr_Name", tbl_Order_Product.ProductPr_ID);
            return View(tbl_Order_Product);
        }

        // GET: Tbl_Order_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Order_Product tbl_Order_Product = db.Tbl_Order_Product.Find(id);
            if (tbl_Order_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderOr_ID = new SelectList(db.Tbl_Order, "Or_ID", "Or_ToName", tbl_Order_Product.OrderOr_ID);
            ViewBag.ProductPr_ID = new SelectList(db.Tbl_Product, "Pr_ID", "Pr_Name", tbl_Order_Product.ProductPr_ID);
            return View(tbl_Order_Product);
        }

        // POST: Tbl_Order_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderOr_ID,ProductPr_ID")] Tbl_Order_Product tbl_Order_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Order_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderOr_ID = new SelectList(db.Tbl_Order, "Or_ID", "Or_ToName", tbl_Order_Product.OrderOr_ID);
            ViewBag.ProductPr_ID = new SelectList(db.Tbl_Product, "Pr_ID", "Pr_Name", tbl_Order_Product.ProductPr_ID);
            return View(tbl_Order_Product);
        }

        // GET: Tbl_Order_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Order_Product tbl_Order_Product = db.Tbl_Order_Product.Find(id);
            if (tbl_Order_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order_Product);
        }

        // POST: Tbl_Order_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Order_Product tbl_Order_Product = db.Tbl_Order_Product.Find(id);
            db.Tbl_Order_Product.Remove(tbl_Order_Product);
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
