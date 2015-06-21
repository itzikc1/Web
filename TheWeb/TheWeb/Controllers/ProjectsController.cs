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
    public class ProjectsController : Controller
    {

        
        private Date db = new Date();

        //
        // GET: /Projects/

        public ActionResult Index()
        {
            return View(db.projects.ToList());
        }

        //
        // GET: /Projects/Details/5

        public ActionResult Details(int id = 0)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Projects/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(project project)
        {
            
           while(db.projects.Find(project.IDproject) != null)
           {
               project.IDproject++;
           }
           if (ModelState.IsValid)
           {

               db.projects.Add(project);
               db.SaveChanges();
               return RedirectToAction("Index");
           }

            return View(project);
        }

        //
        // GET: /Projects/Edit/5

        public ActionResult Edit(int id = 0)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Projects/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            project project = db.projects.Find(id);
            db.projects.Remove(project);
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