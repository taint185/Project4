using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Repository;
using PagedList;
using PagedList.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();
        

        public ActionResult HomePage(int? page)
        {
            var product = iProductRepository.ShowAll();
            int pageNumber = page ?? 1;
            var pageSize = product.ToPagedList(pageNumber, 6);

            ViewBag.latestProducts = pageSize;
            ViewBag.featuredProducts = iProductRepository.FeaturedProducts(3);
            return View();
        }
        public ActionResult CustomerPage()
        {
            ViewBag.latestProducts = iProductRepository.LatestProducts(6);
            ViewBag.featuredProducts = iProductRepository.FeaturedProducts(3);
            return View();
        }

        public ActionResult AdminPage()
        {           
            return View("AdminPage");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}