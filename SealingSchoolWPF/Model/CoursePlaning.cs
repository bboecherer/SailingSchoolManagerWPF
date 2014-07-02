using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class CoursePlaning : SealingSchoolObject
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public virtual int CoursePlaningId { get; set; }
        public virtual CourseStatus CourseStatus { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual BlockedMaterial BlockedMaterial { get; set; }
        public virtual Course Course { get; set; }

        [InverseProperty("CoursePlanings")]
        public virtual ICollection<Instructor> Instructors { get; set; }


        public override bool Equals(object obj)
        {
            CoursePlaning Course;
            try
            {
                Course = (CoursePlaning)obj;
            }
            catch (Exception)
            {
                return false;
            }


            if (CoursePlaningId != Course.CoursePlaningId)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.CoursePlaningId;
        }

        public override string ToString()
        {
            return this.Label + " (" + this.StartDate + " - " + this.EndDate + ")";
        }
    }
}