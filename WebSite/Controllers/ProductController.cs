using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Repository;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ProductController : Controller
     
    {
        // GET: Product

        private IBrandRepository iBrandRepository = new BrandRepository();
        private IProductRepository iProductRepository = new ProductRepository();

        public ActionResult Brand(int id)
        {
            var brand = iBrandRepository.find(id);
            ViewBag.brand = brand;
            ViewBag.products = brand.Products.ToList();
            return View("Brand");
        }

        public ActionResult Details(int id)
        {

            ViewBag.product = iProductRepository.find(id);
            return View("Details");

        }
        public ActionResult DetailsCustomer(int id)
        {

            ViewBag.product = iProductRepository.find(id);
            return View("DetailsCustomer");

        }
    }
}