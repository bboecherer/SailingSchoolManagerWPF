using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class InfoBox
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
