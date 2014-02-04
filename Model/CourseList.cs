using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchoolManager.Model
{
    public static class CourseList
    {
        public static IList<Course> Courses { get; private set; }

        static CourseList()
        {
            Courses = new List<Course>();
            Course course1 = new Course();
            course1.Label = "Testlabel 1";
            course1.Title = "Testkurs";
            course1.Description = "Gefahren auf hoher See";
            course1.StartDate = DateTime.Now;
            course1.EndDate = DateTime.Now;
            course1.Duration = 2;
            course1.Capacity = 5;

            Course course2 = new Course();
            course2.Label = "Testlabel 2";
            course2.Title = "Testkurs No. 2";
            course2.Description = "Weit hinaus";
            course2.StartDate = DateTime.MinValue;
            course2.EndDate = DateTime.MaxValue;
            course2.Duration = 5;
            course2.Capacity = 15;

            Course course3 = new Course();
            course3.Label = "Testlabel 3";
            course3.Title = "Testkurs Nummer4";
            course3.Description = "Es stürmt";
            course3.StartDate = DateTime.Parse("01.01.2014");
            course3.EndDate = DateTime.Parse("05.01.2014");
            course3.Duration = 1;
            course3.Capacity = 8;

            Courses.Add(course1);
            Courses.Add(course2);
            Courses.Add(course3);


        }
    }
}