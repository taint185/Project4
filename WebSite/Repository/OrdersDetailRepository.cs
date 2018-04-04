using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Repository
{
    public class OrdersDetailRepository : IOrdersDetailRepository
    {

        private DBWatchEntities dbwatch = new DBWatchEntities();
        public void create(OrderDetail orderDetail)
        {
            this.dbwatch.OrderDetails.Add(orderDetail);
            this.dbwatch.SaveChanges();
        }
    }
}