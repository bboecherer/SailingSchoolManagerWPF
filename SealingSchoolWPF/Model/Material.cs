using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Material : SealingSchoolObject
    {
        [Key]
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public MaterialStatus MaterialStatus { get; set; }
        public string RepairAction { get; set; }

    }
}
