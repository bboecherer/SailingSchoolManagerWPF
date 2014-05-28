using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class IncomingInvoice : SealingSchoolObject
    {
        [Key]
        public int IncomingInvoiceId { get; set; }
    }
}
