using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWeb.Dal;
using System.Data;
using System.Data.Entity;
using TheWeb.Models;


namespace TheWeb.Controllers
{
    public class HomeController : Controller
    {
          private Date db = new Date();


        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About(string q)
        {
        
            var about = new AboutNum();

            int NumProject =
              (from p in db.projects
               group p by p.local).Count();
            about.NumProject = NumProject;

               int NumberOfStudentProject = (db.students         // source
             .Join(db.projects,         // target
              c => c.Email,          // FK
              cm => cm.emailContact,   // PK
              (c, cm) => new { StudMail = c, ProMail = cm }) // project result
              .Select(x => x.StudMail)).Count();  // select result2
               about.NumberOfStudentProject = NumberOfStudentProject;

              int Local = (db.students         // source
                .Join(db.projects,         // target
                 c => c.local,          // FK
                 cm => cm.local,   // PK
                 (c, cm) => new { StudLocal = c, ProLocal = cm }) // project result
                 .Select(x => x.StudLocal)).Count();  // select result2
                 about.Local = Local;
                  


              return View(about);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        

        
    }

}
