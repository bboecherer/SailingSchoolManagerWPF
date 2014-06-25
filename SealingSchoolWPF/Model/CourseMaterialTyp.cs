using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class CourseMaterialTyp : SealingSchoolObject
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual MaterialTyp MaterialTyp { get; set; }
        public virtual int Amount { get; set; }

        //public virtual ICollection<Course> CourseMatTyp { get; set; }


        public override bool Equals(object obj)
        {
            try
            {
                CourseMaterialTyp materialTyp = (CourseMaterialTyp)obj;


                if (this.Id != materialTyp.Id)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.Id;
        }
    }
}
