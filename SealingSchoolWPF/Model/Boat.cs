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
        public int BoatID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Decimal Price { get; set; }
        public Currency Currency { get; set; }
        public MaterialStatus MaterialStatus { get; set; }
        public string RepairAction { get; set; }
        public string SerialNumber { get; set; }
        public Decimal CrewAmount { get; set; }
        public MaterialGroup MaterialGroup { get; set; }

    }
}
