using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
  public class Invoice : SealingSchoolObject
  {
    [Key]
    public virtual int InvoiceId { get; set; }
    public virtual Boolean Printed { get; set; }
    public virtual DateTime PaymentTargetDate { get; set; }
    public virtual DateTime PaidDate { get; set; }
    public virtual Decimal NetPrice { get; set; }
    public virtual Decimal GrossPrice { get; set; }
    public virtual Decimal GrossPricePaid { get; set; }
    public virtual Decimal VatAmount { get; set; }
    public virtual Double Vat { get; set; }
    public virtual Decimal SumTotalPrice { get; set; }
    public virtual Currency Currency { get; set; }
    public virtual Adress InvoiceAdress { get; set; }
    public virtual InvoiceStatus InvoiceStatus { get; set; }
    public virtual PaymentStatus PaymentStatus { get; set; }
    public virtual IList<InvoiceItem> InvoiceItems { get; set; }


  }
}