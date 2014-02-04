using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchoolManager.Model
{
    public class Student : SealingSchoolObject
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Address PrimaryAddress { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }


        public override string ToString()
        {
            return "Teilnehmer: " + this.Label;
        }

    }
}