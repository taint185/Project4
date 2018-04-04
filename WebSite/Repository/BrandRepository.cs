using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private DBWatchEntities dbwatch = new DBWatchEntities();

        public Brand find(int id)
        {
            return dbwatch.Brands.Find(id);
        }

        public List<Brand> findAll()
        {
            return dbwatch.Brands.ToList();
        }
    }
}