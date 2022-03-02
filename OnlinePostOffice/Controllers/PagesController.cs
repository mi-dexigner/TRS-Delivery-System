using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using OnlinePostOffice.Models;

namespace OnlinePostOffice.Controllers
{
    public class PagesController : Controller
    {
        private TARSDeliveryDbContext db = new TARSDeliveryDbContext();
        // GET: Pages
        public ActionResult About()
        {
          
            return View();
        }

        // GET: Tracking
        [HttpGet]
        public ActionResult Tracking()
        {
            return View();
        }
        // POST: Tracking
        [HttpPost]
        public ActionResult Tracking(tbl_orders order)
        {
            var tracking_number = order.tracking_number;
            var data = db.tbl_orders.Where(s => s.tracking_number.Equals(tracking_number)).ToList();

            if (data.Count() > 0)
            {
                ViewBag.searchresult = "Result Has Been Found";
                ViewBag.searchResults = true;
                ViewBag.searchtitle = data.FirstOrDefault().title;
                ViewBag.searchtracking_number = data.FirstOrDefault().tracking_number;
                ViewBag.searchservice = data.FirstOrDefault().service_id;
                ViewBag.searchdatesender = data.FirstOrDefault().date_sender;
                ViewBag.searchdatereceiver = data.FirstOrDefault().date_reciver;
                ViewBag.searchstatus = data.FirstOrDefault().status;

                ModelState.Clear();
                return View(order);
            }
            else {
                ViewBag.searchresult = "Result Not Found";
                ModelState.Clear();
                return View(data);

            }
        }


        // GET: Tracking
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Contact(string Name, string Email, string Phone,string Message)
        {
            try {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(Email);
                    mail.From = new MailAddress("flktest5@gmail.com");
                    mail.Subject = "Contact Form Query";
                    string Body = Name + Email + Phone + Message;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("flktest5@gmail.com", "Qw4hddqcrg"); // Enter seders User name and password       
                    smtp.EnableSsl = false;
                    smtp.Send(mail);
                    TempData["Success"] = "Message Send";
                    return View();
                }
            }
            catch (Exception)
            {
                TempData["Danger"] = "Some Error";
            }
            return View();
        }
    }

}