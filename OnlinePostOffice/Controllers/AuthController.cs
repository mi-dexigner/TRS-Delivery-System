using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlinePostOffice.Models;

namespace OnlinePostOffice.Controllers
{
    public class AuthController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        // POst: Auth
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var checkAuth = db.tbl_users.FirstOrDefault(u => u.username == username && u.password == password);

            if (checkAuth != null)
            {
                Session["username"] = checkAuth.username;
                Session["fullname"] = checkAuth.full_name;
                Session["role"] = checkAuth.role;
                Session["id"] = checkAuth.id;
                TempData["Success"] = "Successfully Loggin!";
                return RedirectToAction("Index", "Dashboard");
            }
            else if (checkAuth == null)
            {
                TempData["Danger"] = "sorry invalid login credentials";
            }
            return View();
        }

        public ActionResult Register()
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

            [HttpPost]
        public ActionResult Register([Bind(Include = "id,full_name,username,email,phone,password,role,created_at,updated_at")] tbl_users tbl_users)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.tbl_users.Add(tbl_users);
                    db.SaveChanges();
                    TempData["Success"] = "Record saved successfully";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Danger"] = "Error while saving record";
            }

            return View(tbl_users);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index","Auth");
        }
    }
}