using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Course : SealingSchoolObject
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public virtual int CourseId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Decimal NetPrice { get; set; }
        public virtual Decimal GrossPrice { get; set; }
        public virtual Decimal NetAmount { get; set; }
        public virtual int Duration { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual CourseStatus CourseStatus { get; set; }
        public virtual int Credits { get; set; }
        public virtual int Capacity { get; set; }
        public virtual Instructor Instructor { get; set; }
        //   public virtual IList<Qualification> Qualifications { get; set; }

        public override bool Equals(object obj)
        {
            Course course = (Course)obj;

            if (CourseId != course.CourseId)
            {
                return false;
            }

            if (Label != course.Label)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.CourseId;
        }

        public override string ToString()
        {
            return "Kurs: " + this.Title;
        }

    }
}