using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual int NeededInstructors { get; set; }
        public virtual Double RatingValue { get; set; }
        public virtual ICollection<CourseMaterialTyp> CourseMaterialTyps { get; set; }
        public virtual BoatTyp BoatTyp { get; set; }


        [InverseProperty("Courses")]
        public virtual ICollection<Qualification> Qualifications { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<CoursePlaning> CoursePlanings { get; set; }

        public override bool Equals(object obj)
        {
            Course course;
            try
            {
                course = (Course)obj;
            }
            catch (Exception)
            {
                return false;
            }

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
            return this.Label;
        }

    }
}