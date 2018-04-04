using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private DBWatchEntities dbwatch = new DBWatchEntities();

        public void create(Customer customer)
        {
            dbwatch.Customers.Add(customer);
            dbwatch.SaveChanges();
        }

   
    }
}