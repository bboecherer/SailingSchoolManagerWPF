using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class PurchaseOrder : SealingSchoolObject
    {
        [Key]
        public int PurchaseOrderId { get; set; }
    }
}
