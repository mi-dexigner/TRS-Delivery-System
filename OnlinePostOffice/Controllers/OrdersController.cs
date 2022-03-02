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
    public class OrdersController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                ViewBag.users = db.tbl_users.ToList();
                ViewBag.services = db.tbl_services.ToList();
                return View(db.tbl_orders.ToList());
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }



        // GET: Orders/Create
        public ActionResult Create()
        {
            if (Session["id"] != null)
            {

                ViewBag.services = db.tbl_services.ToList();
            return View();
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,tracking_number,sender_name,sender_phone,sender_location,service_id,reciver_name,reciver_phone,reciver_location,date_sender,date_reciver,user_id,created_at,updated_at,cost,weights,status")] tbl_orders tbl_orders)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.tbl_orders.Add(tbl_orders);
                db.SaveChanges();
                    TempData["Success"] = "Record saved successfully";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Danger"] = "Error while saving record";
            }

            return View(tbl_orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] != null)
            {
                ViewBag.services = db.tbl_services.ToList();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbl_orders tbl_orders = db.tbl_orders.Find(id);
                if (tbl_orders == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_orders);
            }
            else
            {
                return RedirectToAction("Index", "auth");
            }
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,tracking_number,sender_name,sender_phone,sender_location,service_id,reciver_name,reciver_phone,reciver_location,date_sender,date_reciver,user_id,created_at,updated_at,cost,weights,status")] tbl_orders tbl_orders)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(tbl_orders).State = EntityState.Modified;
                db.SaveChanges();
                    TempData["Success"] = "Record updated successfully";
                    return RedirectToAction("Index");
            }
            }
            catch
            {
                TempData["Danger"] = "Error while updating record";
            }
            return View(tbl_orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                tbl_orders tbl_orders = db.tbl_orders.Find(id);
            db.tbl_orders.Remove(tbl_orders);
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
