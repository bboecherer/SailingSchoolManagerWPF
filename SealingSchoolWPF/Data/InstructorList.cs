using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public static class InstructorList
    {
        public static IList<Instructor> Instructors { get; private set; }

        static InstructorList()
        {
            Instructors = new List<Instructor>(){
                new Instructor() {Label="Test Lehrer 1", FirstName="Test", LastName= "Lehrer 1", City="City1",ZipCode="54321", AddressLine1="Address1"},
                new Instructor() {Label="Test Lehrer 2", FirstName="Test", LastName= "Lehrer 2", City="City2",ZipCode="11111", AddressLine1="Address2"},
                new Instructor() {Label="Test Lehrer 3", FirstName="Test", LastName= "Lehrer 3", City="City3",ZipCode="22222", AddressLine1="Address3"}
            };
        }
    }
}
