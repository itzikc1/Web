using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWeb.Models;
using TheWeb.Dal;

namespace TheWeb.Controllers
{
    public class StudentsController : Controller
    {
        private Date db = new Date();

        //
        // GET: /Students/

        public ActionResult Index()
        {
            return View(db.students.ToList());
        }

        //
        // GET: /Students/Details/5

        public ActionResult Details(int id = 0)
        {
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Students/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Students/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(student student)
        {
            
           while(db.students.Find(student.IDstudent) != null)
           {
               student.IDstudent++;
           }
           if (ModelState.IsValid)
           {

               db.students.Add(student);
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           
            return View(student);
        }
        
        //    if (ModelState.IsValid)
           // {
            //    db.students.Add(student);
           // /    db.SaveChanges();
           //     return RedirectToAction("Index");
           // }

           // return View(student);
       // }

        //
        // GET: /Students/Edit/5

        public ActionResult Edit(int id = 0)
        {
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Students/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Students/Delete/5

        public ActionResult Delete(int id = 0)
        {
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Students/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}