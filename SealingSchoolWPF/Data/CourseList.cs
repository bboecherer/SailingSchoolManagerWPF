using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public static class CourseList
    {
        public static IList<Course> Courses { get; private set; }

        static CourseList()
        {
            Courses = new List<Course>(){
                new Course() {Label="Kurs 1", Description="Test 1", AdditionalInfo= "Auf hoher See", Capacity=1,Duration=1},
                new Course() {Label="Kurs 2", Description="Test 2", AdditionalInfo= "Zu tief", Capacity=2,Duration=2},
                new Course() {Label="Kurs 3", Description="Test 3", AdditionalInfo= "Wellengang", Capacity=3,Duration=3}
            };
        }
    }
}
