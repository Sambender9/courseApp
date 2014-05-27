using CourseApp.Data;
using CourseApp.DataModels;
using CourseApp.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseApp.Web.Adapters.DataAdapters
{
    public class CourseAdapter : ICourse
    {

        public IEnumerable<Course> GetCourses()
        {
            List<Course> Courses = new List<Course>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Courses = db.Courses.ToList();
            }

            return Courses;
        }

        public void AddCourse(Course course)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public void DeleteCourse(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Course course = db.Courses.Find(Id);

                db.Courses.Remove(course);
                db.SaveChanges();
            }
        }
    }
}