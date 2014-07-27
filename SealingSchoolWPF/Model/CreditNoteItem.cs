using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The CreditNoteItem Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreditNoteItem : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public Currency Currency { get; set; }
        /// <summary>
        /// Gets or sets the net price.
        /// </summary>
        /// <value>
        /// The net price.
        /// </value>
        public Decimal NetPrice { get; set; }
        /// <summary>
        /// Gets or sets the gross price.
        /// </summary>
        /// <value>
        /// The gross price.
        /// </value>
        public Decimal GrossPrice { get; set; }
        /// <summary>
        /// Gets or sets the vat amount.
        /// </summary>
        /// <value>
        /// The vat amount.
        /// </value>
        public Decimal VatAmount { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public Double Amount { get; set; }
        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>
        /// The vat.
        /// </value>
        public Double Vat { get; set; }
        /// <summary>
        /// Gets or sets the service start date.
        /// </summary>
        /// <value>
        /// The service start date.
        /// </value>
        public DateTime ServiceStartDate { get; set; }
        /// <summary>
        /// Gets or sets the service end date.
        /// </summary>
        /// <value>
        /// The service end date.
        /// </value>
        public DateTime ServiceEndDate { get; set; }
        /// <summary>
        /// Gets or sets the service location.
        /// </summary>
        /// <value>
        /// The service location.
        /// </value>
        public String ServiceLocation { get; set; }

    }
}