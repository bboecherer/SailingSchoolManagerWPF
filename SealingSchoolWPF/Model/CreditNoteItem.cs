using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class CreditNoteItem : SealingSchoolObject
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal GrossPrice { get; set; }
        public Decimal VatAmount { get; set; }
        public Double Amount { get; set; }
        public Double Vat { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public String ServiceLocation { get; set; }
        
    }
}