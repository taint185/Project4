using WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Repository;
namespace WebSite.Controllers
{
    public class OrderController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();
        private IOrdersRepository iOrdersRepository = new OrdersRepository();
        private IOrdersDetailRepository iOrdersDetailRepository = new OrdersDetailRepository();
        // GET: Cart
        public ActionResult ViewCart()
        {
            return View("ViewCart");
        }
        public ActionResult Buy(int id)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item()
                    {
                        product = iProductRepository.find(id),
                        quantity = 1
                    });
                    Session["cart"] = cart;
                }
                else
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    int index = isExits(id);
                    if (index == -1)
                    {
                        cart.Add(new Item()
                        {
                            product = iProductRepository.find(id),
                            quantity = 1
                        });
                    }
                    else
                    {
                        cart[index].quantity = cart[index].quantity + 1;
                    }
                    Session["cart"] = cart;
                }
                return View("ViewCart");
            }
        }

        private int isExits(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];

            for( int i =0;i < cart.Count; i++)
            {
                if (cart[i].product.ProID == id)
                    return i;
            }
            return -1;
        }
        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("ViewCart");
        }

        public ActionResult Checkout()
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                //save order
                Order order = new Order();
                order.Date = DateTime.Now;
                order.Payment = "Card";
                order.Status = true;
                order.CusName = Session["userName"].ToString();
                int orderId = iOrdersRepository.create(order);
                //save order detail
                foreach(var item in cart)
                {
                    OrderDetail ordersdetail = new OrderDetail();
                    ordersdetail.OrderID = orderId;

                    ordersdetail.ProID = item.product.ProID;
                    ordersdetail.Price = item.product.Price;
                    ordersdetail.Quantity = item.quantity;
                    iOrdersDetailRepository.create(ordersdetail);
                }
                Session.Remove("cart");
                //remove cart
                return View("Thanks");
            }
        }
    }
   
    
}