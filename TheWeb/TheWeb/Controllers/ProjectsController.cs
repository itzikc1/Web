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

       
        public ActionResult Index(string searchString) 
{           
     var project1 = from m in db.projects 
                  select m;
     var project2 = from m in db.projects
                    select m;

     
    if (!String.IsNullOrEmpty(searchString)) 
    {
        int i=0;
       
        project1 = project1.Where(s => s.NameProject.Contains(searchString));
        foreach (var item in project1)
            i++;
        
        if(i!=0)
        return View(project1);

        i = 0;
        project2 = project2.Where(s => s.local.Contains(searchString));
        foreach (var item in project2)
              i++;

        if (i != 0)
            return View(project2); 
    }

    return View(project1); 
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
           [Authorize]
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
      [Authorize]
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