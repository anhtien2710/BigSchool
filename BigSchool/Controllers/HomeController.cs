using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        BigSchoolContext context = new BigSchoolContext();
        public ActionResult Index()
        {
            var upcommingCourse = context.Courses.Where(x => x.DateTime > DateTime.Now).OrderBy(x => x.DateTime).ToList();
            foreach (Course item in upcommingCourse)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().
                    GetUserManager<ApplicationUserManager>().FindById(item.LecturerId);
                item.Name = user.Name;
            }

            return View(upcommingCourse);
        }
    }
}