using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The CreditNote Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreditNote : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual int Id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreditNote"/> is printed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if printed; otherwise, <c>false</c>.
        /// </value>
        public virtual Boolean Printed { get; set; }
        /// <summary>
        /// Gets or sets the credit date.
        /// </summary>
        /// <value>
        /// The credit date.
        /// </value>
        public virtual DateTime CreditDate { get; set; }
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
        /// Gets or sets the gross price paid.
        /// </summary>
        /// <value>
        /// The gross price paid.
        /// </value>
        public virtual Decimal GrossPricePaid { get; set; }
        /// <summary>
        /// Gets or sets the vat amount.
        /// </summary>
        /// <value>
        /// The vat amount.
        /// </value>
        public virtual Decimal VatAmount { get; set; }
        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>
        /// The vat.
        /// </value>
        public virtual Double Vat { get; set; }
        /// <summary>
        /// Gets or sets the credit note adress.
        /// </summary>
        /// <value>
        /// The credit note adress.
        /// </value>
        public virtual Adress CreditNoteAdress { get; set; }
        /// <summary>
        /// Gets or sets the credit note items.
        /// </summary>
        /// <value>
        /// The credit note items.
        /// </value>
        public virtual IList<CreditNoteItem> CreditNoteItems { get; set; }

    }
}