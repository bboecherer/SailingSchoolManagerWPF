using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class CreditNote : SealingSchoolObject
    {
        public virtual int Id { get; set; }
        public virtual Boolean Printed { get; set; }
        public virtual DateTime CreditDate { get; set; }
        public virtual Decimal NetPrice { get; set; }
        public virtual Decimal GrossPrice { get; set; }
        public virtual Decimal GrossPricePaid { get; set; }
        public virtual Decimal VatAmount { get; set; }
        public virtual Double Vat { get; set; }
        public virtual Adress CreditNoteAdress { get; set; }
        public virtual IList<CreditNoteItem> CreditNoteItems { get; set; }

    }
}