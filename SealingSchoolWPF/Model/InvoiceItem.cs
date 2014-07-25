using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The InvoiceItem Model
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// Gets or sets the invoice item identifier.
        /// </summary>
        /// <value>
        /// The invoice item identifier.
        /// </value>
        [Key]
        public virtual int InvoiceItemId { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public virtual Currency Currency { get; set; }
        /// <summary>
        /// Gets or sets the net price.
        /// </summary>
        /// <value>
        /// The net price.
        /// </value>
        public virtual Decimal NetPrice { get; set; }
        /// <summary>
        /// Gets or sets the gross price.
        /// </summary>
        /// <value>
        /// The gross price.
        /// </value>
        public virtual Decimal GrossPrice { get; set; }
        /// <summary>
        /// Gets or sets the vat amount.
        /// </summary>
        /// <value>
        /// The vat amount.
        /// </value>
        public virtual Decimal VatAmount { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public virtual Double Amount { get; set; }
        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>
        /// The vat.
        /// </value>
        public virtual Double Vat { get; set; }
        /// <summary>
        /// Gets or sets the service start date.
        /// </summary>
        /// <value>
        /// The service start date.
        /// </value>
        public virtual DateTime ServiceStartDate { get; set; }
        /// <summary>
        /// Gets or sets the service end date.
        /// </summary>
        /// <value>
        /// The service end date.
        /// </value>
        public virtual DateTime ServiceEndDate { get; set; }
        /// <summary>
        /// Gets or sets the service location.
        /// </summary>
        /// <value>
        /// The service location.
        /// </value>
        public virtual String ServiceLocation { get; set; }
        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public virtual Invoice Invoice { get; set; }
    }
}