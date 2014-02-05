using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public static class StudentList
    {
        public static IList<Student> Students { get; private set; }

        static StudentList()
        {
            Students = new List<Student>()
        {
            new Student(){Label = "John Doe",FirstName="John", LastName="Doe",
                AddressLine1 = "Onestreet",
                 ZipCode= "12345",
                City = "Onecity"},
            new Student(){Label = "Jane Doe",
                AddressLine1 = "Onestreet",
                ZipCode = "12345",
                City = "Onecity"},
            new Student(){Label = "Foo Bar",
                AddressLine1 = "Twostreet",
                ZipCode = "54321",
                City = "Twocity"}
        };
        }
    }
}