using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DBWatchEntities dbwatch = new DBWatchEntities();
       
        public Product find(int id)
        {
            return dbwatch.Products.Find(id);
          
        }
        //san pham da sale, show het
        public List<Product> LatestProducts(int n)
        {
            return dbwatch.Products.OrderByDescending(p =>p.ProID).Take(n).ToList();
        }
        //san pham them moi
        public List<Product> FeaturedProducts(int n)
        {
            return dbwatch.Products.Where(p => p.Specials == false).OrderByDescending(p => p.ProID).Take(n).ToList();
        }
        public List<Product> ShowAll()
        {
            return dbwatch.Products.ToList();
        }
        
    }       
}