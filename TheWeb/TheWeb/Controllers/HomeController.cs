using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWeb.Dal;
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


            var ProjectQuery1 =
             from project in db.projects
             group project by project.local;


            var query = db.students         // source
            .Join(db.projects,         // target
             c => c.Email,          // FK
             cm => cm.emailContact,   // PK
             (c, cm) => new { StudMail = c, ProMail = cm }) // project result
             .Select(x => x.StudMail);  // select result




            return View(ProjectQuery1);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        
    }
}
