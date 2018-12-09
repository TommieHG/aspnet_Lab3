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
    public class Tbl_ProductController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        // GET: Tbl_Product
        public ActionResult Index(string searchString)
        {
            //added variable to manipulate in if
            var products = from s in db.Tbl_Product select s;

            //if the searchString isn't empty, pick the fields where data matches searchString and return to view
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Pr_Name.ToUpper().Contains(searchString.ToUpper()) || s.Pr_Quantity.ToString().Contains(searchString.ToUpper()));
            }

            return View(products.ToList());
        }

        // GET: Tbl_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // GET: Tbl_Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pr_ID,Pr_Name,Pr_Quantity")] Tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Product.Add(tbl_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Product);
        }

        // GET: Tbl_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // POST: Tbl_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pr_ID,Pr_Name,Pr_Quantity")] Tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Product);
        }

        // GET: Tbl_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // POST: Tbl_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            db.Tbl_Product.Remove(tbl_Product);
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
