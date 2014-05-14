using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class MaterialTyp : SealingSchoolObject
    {
        [Key]
        public int Id { get; set; }
        public String Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}
