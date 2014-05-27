using CourseApp.Data;
using CourseApp.DataModels;
using CourseApp.Web.Adapters.DataAdapters;
using CourseApp.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseApp.Web.Controllers
{
    public class HomeController : Controller
    {
        ICourse db;

        public HomeController()
        {
            db = new CourseAdapter();
        }

        public HomeController(ICourse _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Course> Courses = db.GetCourses();

            return Json(Courses);
        }

        [HttpPost]
        public ActionResult Index(Course course)
        {
            db.AddCourse(course);

            var courses = db.GetCourses();

            return View(courses);
        }
    }
}