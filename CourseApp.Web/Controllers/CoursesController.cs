using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CourseApp.Data;
using CourseApp.DataModels;
using CourseApp.Web.Adapters.Interfaces;
using CourseApp.Web.Adapters.DataAdapters;

namespace CourseApp.Web.Controllers
{
    public class CoursesController : ApiController
    {
        ICourse db;

        public CoursesController()
        {
            db = new CourseAdapter();
        }

        public CoursesController(ICourse _db)
        {
            db = _db;
        }

        // GET: api/Courses
        public IEnumerable<Course> GetCourses()
        {
            return db.GetCourses();
        }

        //// GET: api/Courses/5
        //[ResponseType(typeof(Course))]
        //public IHttpActionResult GetCourse(int id)
        //{
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(course);
        //}

        //// PUT: api/Courses/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCourse(int id, Course course)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != course.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(course).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CourseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(string courseName)
        {
            Course course = new Course() { Name = courseName };
            db.AddCourse(course);
            

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        //// DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            db.DeleteCourse(id);

            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CourseExists(int id)
        //{
        //    return db.Courses.Count(e => e.Id == id) > 0;
        //}
    }
}