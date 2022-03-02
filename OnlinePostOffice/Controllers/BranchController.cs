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
    public class BranchController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();

        // GET: Branch
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
            ViewBag.users = db.tbl_users.ToList();
            ViewBag.cityList = db.tbl_cities.ToList();
            return View(db.tbl_branch.ToList());
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

       

        // GET: Branch/Create
        public ActionResult Create()
        {
            if (Session["id"] != null)
            {
                ViewBag.cityList = db.tbl_cities.ToList();
            return View();
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

        // POST: Branch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,branch_code,branch_name,email,phone,address,city_id,zipcode,user_id,created_at,updated_at")] tbl_branch tbl_branch)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.tbl_branch.Add(tbl_branch);
                db.SaveChanges();
                    TempData["Success"] = "Record saved successfully";
                    return RedirectToAction("Index");
            }
            }
            catch
            {
                TempData["Danger"] = "Error while saving record";
            }

            return View(tbl_branch);
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_branch tbl_branch = db.tbl_branch.Find(id);
            if (tbl_branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.cityList = db.tbl_cities.ToList();
            return View(tbl_branch);
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

        // POST: Branch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,branch_code,branch_name,email,phone,address,city_id,zipcode,user_id,created_at,updated_at")] tbl_branch tbl_branch)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(tbl_branch).State = EntityState.Modified;
                db.SaveChanges();
                    TempData["Message"] = "Record updated successfully";
                    return RedirectToAction("Index");
            }
            }
            catch
            {
                TempData["Message"] = "Error while updating record";
            }
            return View(tbl_branch);
        }

        // GET: Branch/Delete/5
  
        public ActionResult Delete(int id)
        {
            try
            {
                tbl_branch tbl_branch = db.tbl_branch.Find(id);
            db.tbl_branch.Remove(tbl_branch);
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
