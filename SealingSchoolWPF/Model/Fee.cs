using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }

        //Das Datum des Inkrafttretens
        public DateTime ValidFrom { get; set; }

        public Double Percentage { get; set; }
    }
}
