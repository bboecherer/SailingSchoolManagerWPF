using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Qualification : SealingSchoolObject
    {
        [Key]
        public int QualificationId { get; set; }
        public String ShortName { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? IssuingDate { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public override string ToString()
        {
            return this.ShortName;
        }

        public override bool Equals(object obj)
        {
            try
            {
                Qualification quali = (Qualification)obj;


                if (QualificationId != quali.QualificationId)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.QualificationId;
        }

    }
}
