using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Invoice: InvoiceAddress
    {
        public int Id { get; set; }
        public Boolean Printed { get; set; }
        public InvoiceAddress InvoiceAddress = new InvoiceAddress();
        public DateTime PaymentTargetDate { get; set; }
        public DateTime PaidDate { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal GrossPrice { get; set; }
        public Decimal GrossPricePaid { get; set; }
        public Decimal VatAmount { get; set; }
        public Double Vat { get; set; }
        public Decimal SumTotalPrice { get; set; }
        public Currency Currency { get; set; }
        public SortedSet<InvoiceItem> Items = new SortedSet<InvoiceItem>();
        

        public InvoiceStatus InvoiceStatus = InvoiceStatus.RECHNUNG;


        public PaymentStatus PaymentStatus = PaymentStatus.NICHT_GEZAHLT;
        
        public void SetItems( SortedSet<InvoiceItem> Items ) {
            this.Items = Items;
        }
        
        public SortedSet<InvoiceItem> GetItems() {  
            return this.Items; 
        }

    }
}