using CourseApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Web.Adapters.Interfaces
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourses();

        void AddCourse(Course course);

        void DeleteCourse(int Id);
    }
}
