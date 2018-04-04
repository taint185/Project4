using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Repository;

namespace WebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private DBWatchEntities dbwatch = new DBWatchEntities();
        private IBrandRepository iBrandRepository = new BrandRepository();
        private ICustomerRepository iCustomerRepository = new CustomerRepository();
        private IProductRepository iProductRepository = new ProductRepository();
        public ActionResult Index()
        {
            return View();
        }
        //Brand
        public ActionResult ViewBrand(int? page)
        {
            return View(dbwatch.Brands.ToList());
        }
        //add brand
        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrand(Brand newBrand)
        {
            try
            {
                dbwatch = new DBWatchEntities();

                Brand brand = new Brand();
                brand.BrandName = brand.BrandName;
                brand.Description = brand.Description;
          

                //Add data in sql
                dbwatch.Brands.Add(newBrand);

                //Save changes
                dbwatch.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("viewBrand", "Admin");
        }
        //detail brand
        public ActionResult DetailsBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = dbwatch.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        //edit brand
        public ActionResult EditBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = dbwatch.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }        
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBrand([Bind(Include = "BrandID,BrandName,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                dbwatch.Entry(brand).State = EntityState.Modified;
                dbwatch.SaveChanges();
                return RedirectToAction("ViewBrand");
            }
            return View(brand);
        }
        //delete brand
        public ActionResult DeleteBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = dbwatch.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: /Delete/5
        [HttpPost, ActionName("DeleteBrand")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = dbwatch.Brands.Find(id);
            dbwatch.Brands.Remove(brand);
            dbwatch.SaveChanges();
            return RedirectToAction("ViewBrand");
        }

    }
}