using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Repository;

namespace WebSite.Controllers
{
    public class CustomersController : Controller
    {
        private DBWatchEntities db = new DBWatchEntities();
        private ICustomerRepository iCustomerRepository = new CustomerRepository();
        // GET: Customers
        public ActionResult ViewDetailsCustomer(string cus)
        {
            if (cus == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(cus);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Details/5
        //edit customer
        public ActionResult EditCustomer(string cusName)
        {
            if (cusName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(cusName);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CusName,Password,FullName,BirthDay,Gender,Email,Phone,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThanksEdit", "Customers");
            }
            return View(customer);
        }
        public ActionResult ThanksEdit()
        {
            return View("ThanksEdit");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult SendMail(string Title, string Content, string From)
        {
            // Tạo thư
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(db.Customers.ElementAt(0).Email, 2);
            mail.To.Add("taint1805@gmail.com");
            mail.Subject = Title;
            mail.Body = Content;
            mail.ReplyToList.Add(mail.From);

            try
            {
                // Kết nối bưu điện
                var smtp = new SmtpClient("smtp.gmail.com", 25)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(From, "javapostoffice@2000")
                };

                // Gửi thư
                smtp.Send(mail);

                ViewBag.Message = "Gửi mail thành công";
            }
            catch
            {
                ViewBag.Message = "Gửi mail thất bại";
            }

            return View();
        }
    }
}
