using De.SealingSchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchool.ModellOutput
{
    class ConsoleOutput
    {
        static void Main(string[] args)
        {
            foreach (var student in StudentList.Students)
            {
                Console.WriteLine(student);
                if (student.PrimaryAddress != null)
                {
                    Console.WriteLine("Anschrift: " + student.PrimaryAddress.AddressLine1 + ", " + student.PrimaryAddress.ZipCode + ", " + student.PrimaryAddress.City);
                }
                Console.WriteLine("-----------------------------------");
            }

            foreach (var instructor in InstructorList.Instructors)
            {
                Console.WriteLine(instructor);
                if (instructor.PrimaryAddress != null)
                {
                    Console.WriteLine("Anschrift: " + instructor.PrimaryAddress.AddressLine1 + ", " + instructor.PrimaryAddress.ZipCode + ", " + instructor.PrimaryAddress.City);
                }
                Console.WriteLine("-----------------------------------");
            }

            foreach (var course in CourseList.Courses)
            {
                Console.WriteLine(course);
                Console.WriteLine("Beschreibung: " + course.Description);
                Console.WriteLine("Start: " + course.StartDate);
                Console.WriteLine("Ende: " + course.EndDate);
                Console.WriteLine("Dauer: " + course.Duration);
                Console.WriteLine("Teilnehmeranzahl: " + course.Capacity);

                Console.WriteLine("-----------------------------------");
            }
            Console.ReadKey();
        }
    }
}
