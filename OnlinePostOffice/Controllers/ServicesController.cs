using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlinePostOffice.Models;

namespace OnlinePostOffice.Controllers
{
    public class ServicesController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();

        // GET: Services
        public ActionResult Index()
        {
            ViewData["userdata"] = db.tbl_users.ToList();
            return View(db.tbl_services.ToList());
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,user_id,created_at,updated_at")] tbl_services tbl_services)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.tbl_services.Add(tbl_services);
                db.SaveChanges();
                TempData["Message"] = "Record saved successfully";
               return RedirectToAction("Index");
            }
            }
            catch
            {
                TempData["Message"] = "Error while saving record";
            }
            return View(tbl_services);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_services tbl_services = db.tbl_services.Find(id);
            if (tbl_services == null)
            {
                return HttpNotFound();
            }
            return View(tbl_services);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,user_id,created_at,updated_at")] tbl_services tbl_services)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(tbl_services).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Record updated successfully";
                return RedirectToAction("Index");
            }
            }
            catch
            {
                TempData["Message"] = "Error while updating record";
            }
            return View(tbl_services);
        }


        // GET: Services/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                tbl_services tbl_services = db.tbl_services.Find(id);
            db.tbl_services.Remove(tbl_services);
            db.SaveChanges();
           TempData["Message"] = "Record Deleted successfully";
            }
            catch
            {
                TempData["Message"] = "Error while deleting record";
            }
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
