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
    public class Tbl_CustomerController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        //GET: Tbl_Customer
        //public ActionResult Index()
        //{
        //    var tbl_Customer = db.Tbl_Customer.Include(t => t.Tbl_Payment_Method);
        //    return View(tbl_Customer.ToList());
        //}

        // GET: Tbl_Customer
        public ActionResult Index(string sortOrder)
        {
            ViewBag.LastnameSort = String.IsNullOrEmpty(sortOrder) ? "Lastname_desc" : "";
            ViewBag.FirstnameSort = sortOrder == "Firstname" ? "Firstname_desc" : "Firstname";      

            var customers = from s in db.Tbl_Customer select s;

            switch (sortOrder)
            {
                case "Lastname_desc":
                    customers = customers.OrderByDescending(s => s.Cu_LastName);
                break;
                case "Firstname":
                    customers = customers.OrderBy(s => s.Cu_FirstName);
                break;
                case "Firstname_desc":
                    customers = customers.OrderByDescending(s => s.Cu_FirstName);
                break;
                default:
                    customers = customers.OrderBy(s => s.Cu_LastName);
                break;
            }

            return View(customers.ToList());
        }

        // GET: Tbl_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Customer tbl_Customer = db.Tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // GET: Tbl_Customer/Create
        public ActionResult Create()
        {
            ViewBag.Cu_Payment = new SelectList(db.Tbl_Payment_Method, "Pa_ID", "Pa_Method");
            return View();
        }

        // POST: Tbl_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cu_ID,Cu_Payment,Cu_FirstName,Cu_LastName,Cu_Street,Cu_ZipCode,Cu_City,Cu_PhoneNo")] Tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Customer.Add(tbl_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cu_Payment = new SelectList(db.Tbl_Payment_Method, "Pa_ID", "Pa_Method", tbl_Customer.Cu_Payment);
            return View(tbl_Customer);
        }

        // GET: Tbl_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Customer tbl_Customer = db.Tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cu_Payment = new SelectList(db.Tbl_Payment_Method, "Pa_ID", "Pa_Method", tbl_Customer.Cu_Payment);
            return View(tbl_Customer);
        }

        // POST: Tbl_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cu_ID,Cu_Payment,Cu_FirstName,Cu_LastName,Cu_Street,Cu_ZipCode,Cu_City,Cu_PhoneNo")] Tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cu_Payment = new SelectList(db.Tbl_Payment_Method, "Pa_ID", "Pa_Method", tbl_Customer.Cu_Payment);
            return View(tbl_Customer);
        }

        // GET: Tbl_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Customer tbl_Customer = db.Tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // POST: Tbl_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Customer tbl_Customer = db.Tbl_Customer.Find(id);
            db.Tbl_Customer.Remove(tbl_Customer);
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
