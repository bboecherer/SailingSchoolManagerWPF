using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{

    public class Student : SealingSchoolObject
    {
        [Key]
        public virtual int StudentId { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual ContactData Contact { get; set; }
        public virtual BankAccountData Bank { get; set; }
     //   public virtual IList<Qualification> Qualifications { get; set; }

        public override bool Equals(object obj)
        {
            Student stud = (Student)obj;

            if (StudentId != stud.StudentId)
            {
                return false;
            }

            if (Label != stud.Label)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.StudentId;
        }
    }
}