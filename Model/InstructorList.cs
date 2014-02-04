using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchoolManager.Model
{
    public static class InstructorList
    {
        public static IList<Instructor> Instructors { get; private set; }

        static InstructorList()
        {
            Instructors = new List<Instructor>();
            Instructor instr1 = new Instructor();
            instr1.Label = "Lehrer NoOne";
            instr1.FirstName = "Lehrer";
            instr1.LastName = "NoOne";

            Instructor instr2 = new Instructor();
            instr2.Label = "Max Mustermann";
            instr2.FirstName = "Max";
            instr2.LastName = "Musterman";

            Instructor instr3 = new Instructor();
            instr3.Label = "Rosa Schlüpfer";
            instr3.FirstName = "Rosa";
            instr3.LastName = "Schlüpfer";

            Address a1 = new Address();
            a1.AddressLine1 = "Musterstraße 2";
            a1.ZipCode = "54321";
            a1.City = "Musterhausen";

            instr1.PrimaryAddress = a1;

            Instructors.Add(instr1);
            Instructors.Add(instr2);
            Instructors.Add(instr3);


        }
    }
}