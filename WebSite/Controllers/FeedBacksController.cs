using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class FeedBacksController : Controller
    {
        private DBWatchEntities db = new DBWatchEntities();

        // GET: FeedBacks
        public ActionResult Index(string cusName)
        {
            
            //var fbcus = from f in db.FeedBacks select f;
            //if (!String.IsNullOrEmpty(cusName))
            //{
            //    fbcus = fbcus.Where(f => f.CusName.Contains(cusName));
            //}
           
            return View();
        }

        // GET: FeedBacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);

            if (feedBack == null)
            {
                return HttpNotFound();
            }
            else
            {
                feedBack.Status = false;
                db.Entry(feedBack).State = EntityState.Modified;
                db.SaveChanges();

            }
            ViewBag.tt = feedBack;
            return View();
        }

        // GET: FeedBacks/Create
        public ActionResult Create()
        {
            ViewBag.CusName = new SelectList(db.Customers, "CusName", "Password");
            return View();
        }

        // POST: FeedBacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FBackID,Title,Content,Status,CusName")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {

                db.FeedBacks.Add(feedBack);
                db.SaveChanges();
                feedBack.Status = true;
                db.Entry(feedBack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CusName = new SelectList(db.Customers, "CusName", "Password", feedBack.CusName);
            return View(feedBack);
        }

        // GET: FeedBacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            ViewBag.CusName = new SelectList(db.Customers, "CusName", "Password", feedBack.CusName);
            return View(feedBack);
        }

        // POST: FeedBacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FBackID,Title,Content,Status,CusName")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(feedBack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CusName = new SelectList(db.Customers, "CusName", "Password", feedBack.CusName);
            return View(feedBack);
        }

        // GET: FeedBacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedBack feedBack = db.FeedBacks.Find(id);
            db.FeedBacks.Remove(feedBack);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
