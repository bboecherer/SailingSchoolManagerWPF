using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Material : SealingSchoolObject
    {
        [Key]
        public virtual int MaterialId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Brand { get; set; }
        public virtual Decimal Price { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual MaterialStatus MaterialStatus { get; set; }
        public virtual MaterialTyp MaterialTyp { get; set; }
        public virtual string RepairAction { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual CoursePlaning CoursePlaning { get; set; }

        [InverseProperty("Material")]
        public virtual ICollection<BoatTyp> BoatTyps { get; set; }

       

    }
}
