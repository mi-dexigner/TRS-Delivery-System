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
    public class UsersController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                return View(db.tbl_users.ToList());

            }
            else
            {
                return RedirectToAction("Index", "auth");

            }
        }

        // GET: Users/Create
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

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,full_name,username,email,phone,password,role,created_at,updated_at")] tbl_users tbl_users,FormCollection fc)
        {
            var emailInput = Request.Form["email"];
            var check = db.tbl_users.FirstOrDefault(s => s.email == emailInput);
            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    db.tbl_users.Add(tbl_users);
                    db.SaveChanges();
                    TempData["Success"] = "User Registration Successfully";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Danger"] = "Email already exists";
                return View();
               
            }

            return View(tbl_users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbl_users tbl_users = db.tbl_users.Find(id);
                if (tbl_users == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_users);
            }
            else
            {
                return RedirectToAction("Index", "auth");

            }
           
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,full_name,username,email,phone,password,role,created_at,updated_at")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            tbl_users tbl_users = db.tbl_users.Find(id);
            db.tbl_users.Remove(tbl_users);
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
