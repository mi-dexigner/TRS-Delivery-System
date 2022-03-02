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
    public class CitiesController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();

        // GET: Cities
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                ViewBag.users = db.tbl_users.ToList();
                return View(db.tbl_cities.ToList());
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
            
        }


        // GET: Cities/Create
        public ActionResult Create()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,user_id,created_at,updated_at")] tbl_cities tbl_cities)
        {
            try
            {
                if (ModelState.IsValid)
            {
                
                    db.tbl_cities.Add(tbl_cities);
                db.SaveChanges();
                TempData["Success"] = "Record saved successfully";
                return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Danger"] = "Error while saving record";
            }

            return View(tbl_cities);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cities tbl_cities = db.tbl_cities.Find(id);
            if (tbl_cities == null)
            {
                return HttpNotFound();
            }
            return View(tbl_cities);
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,user_id,created_at,updated_at")] tbl_cities tbl_cities)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(tbl_cities).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Record updated successfully";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Danger"] = "Error while updating record";
            }
            return View(tbl_cities);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                tbl_cities tbl_cities = db.tbl_cities.Find(id);
                db.tbl_cities.Remove(tbl_cities);
                db.SaveChanges();
                TempData["Success"] = "Record Deleted successfully";
            }
            catch
            {
                TempData["Danger"] = "Error while deleting record";
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
