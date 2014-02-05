using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Course : SealingSchoolObject
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal GrossPrice { get; set; }
        public Decimal NetAmount { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Currency { get; set; }
        public String Status { get; set; }
        public int Credits { get; set; }
        public int Capacity { get; set; }
        public Instructor Instructor { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public override string ToString()
        {
            return "Kurs: " + this.Title;
        }

    }
}