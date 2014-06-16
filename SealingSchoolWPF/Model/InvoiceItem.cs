using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
  public class InvoiceItem
  {
    [Key]
    public virtual int InvoiceItemId { get; set; }
    public virtual Currency Currency { get; set; }
    public virtual Decimal NetPrice { get; set; }
    public virtual Decimal GrossPrice { get; set; }
    public virtual Decimal VatAmount { get; set; }
    public virtual Double Amount { get; set; }
    public virtual Double Vat { get; set; }
    public virtual DateTime ServiceStartDate { get; set; }
    public virtual DateTime ServiceEndDate { get; set; }
    public virtual String ServiceLocation { get; set; }
    public virtual Invoice Invoice { get; set; }
  }
}