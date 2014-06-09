using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class BoatTyp : SealingSchoolObject
    {
        [Key]
        public int BoatID { get; set; }
        public string Name { get; set; }
        public Decimal CrewAmount { get; set; }
        public String Description { get; set; }

    }
}
