using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private DBWatchEntities dbwatch = new DBWatchEntities();

        public int create(Order order)
        {
            this.dbwatch.Orders.Add(order);
            this.dbwatch.SaveChanges();
            return order.OrderID;
        }
    }
}