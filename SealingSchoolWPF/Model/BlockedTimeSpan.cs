using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class BlockedTimeSpan
    {
        [Key]
        public virtual int BlockedTimeSpanId { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
