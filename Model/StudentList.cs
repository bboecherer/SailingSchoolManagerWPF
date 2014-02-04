using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchoolManager.Model
{
    public static class StudentList
    {
        public static IList<Student> Students { get; private set; }

        static StudentList()
        {
            Students = new List<Student>();
            Student std1 = new Student();
            std1.Label = "John Doe";
            std1.FirstName = "John";
            std1.LastName = "Doe";

            Student std2 = new Student();
            std2.Label = "Ede Pfau";
            std2.FirstName = "Ede";
            std2.LastName = "Pfau";

            Student std3 = new Student();
            std3.Label = "Polly Morphie";
            std3.FirstName = "Polly";
            std3.LastName = "Morphie";

            Address a1 = new Address();
            a1.AddressLine1 = "Musterstraße 1";
            a1.ZipCode = "12345";
            a1.City = "Musterhausen";

            std1.PrimaryAddress = a1;

            Students.Add(std1);
            Students.Add(std2);
            Students.Add(std3);


        }
    }
}