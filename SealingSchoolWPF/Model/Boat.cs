using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Boat : SealingSchoolObject
    {
        [Key]
        public virtual int BoatID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Brand { get; set; }
        public virtual Decimal Price { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual MaterialStatus MaterialStatus { get; set; }
        public virtual string RepairAction { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual BoatTyp BoatTyp { get; set; }
        public virtual String Description { get; set; }

        public virtual CoursePlaning CoursePlaning { get; set; }

    }
}
