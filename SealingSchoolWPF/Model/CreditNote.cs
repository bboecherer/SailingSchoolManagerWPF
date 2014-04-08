using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class CreditNote
    {
        public int Id { get; set; }
        public Boolean Printed { get; set; }
        public DateTime CreditDate { get; set; }
        public SortedSet<CreditNoteItem> Items = new SortedSet<CreditNoteItem>();
        public Decimal NetPrice { get; set; }
        public Decimal GrossPrice { get; set; }
        public Decimal GrossPricePaid { get; set; }
        public Decimal VatAmount { get; set; }
        public Double Vat { get; set; }
        public Adress CreditNoteAdress { get; set; }
        
        public void SetItems(SortedSet<CreditNoteItem> Items)
        {
            this.Items = Items;
        }

        public SortedSet<CreditNoteItem> GetItems()
        {
            return this.Items;
        }
    }
}