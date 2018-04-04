using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Repository;


namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //private ICustomerRepository iCustomerRepository = new CustomerRepository();
        //[HttpGet]
        //public ActionResult MyAccount()
        //{
        //    return View("MyAccount");
        //}

        //[HttpPost]
        //public ActionResult MyAccount(Customer customer)
        //{
        //    iCustomerRepository.create(customer);
        //    return RedirectToAction("Register","Account");
        //}

        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login lg)
        {
            if (ModelState.IsValid)
            {
                using (DBWatchEntities dbwatch = new DBWatchEntities())
                {

                    var user = dbwatch.Customers.Where(a => a.CusName.Equals(lg.username) && a.Password.Equals(lg.password)).FirstOrDefault();
                    var admin = dbwatch.Admins.Where(a => a.username.Equals(lg.username) && a.password.Equals(lg.password)).FirstOrDefault();
                    if (user != null)
                    {
                        //luu hien thi ten tren web
                        Session["userName"] = user.CusName.ToString();
                        Session["fullName"] = user.FullName.ToString();
                        Response.Write("<script>window.history.go(-2);</script>");
                        //return Redirect("JavaScript: history.go(-1)");
                        

                    }
                    else if (admin != null)
                    {
                        Session["userName"] = admin.username.ToString();
                        Session["userID"] = admin.id;
                        return RedirectToAction("AdminPage", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong!");
                    }
                }
            }
            
            return View();
            
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cus)
        {
            if (ModelState.IsValid)
            {
                using (DBWatchEntities dbwatch = new DBWatchEntities())
                {
                    dbwatch.Customers.Add(cus);
                    dbwatch.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = cus.CusName + " successfully registered.";
            }
            return View("Register");
        }
        public ActionResult Logout()
        {
            //Session.Clear();
            //Session.Abandon();
            //return RedirectToAction("HomePage", "Home");
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}