using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The Invoice Model
    /// </summary>
    public class Invoice : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        [Key]
        public virtual int InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Invoice"/> is printed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if printed; otherwise, <c>false</c>.
        /// </value>
        public virtual Boolean Printed { get; set; }
        /// <summary>
        /// Gets or sets the payment target date.
        /// </summary>
        /// <value>
        /// The payment target date.
        /// </value>
        public virtual DateTime PaymentTargetDate { get; set; }
        /// <summary>
        /// Gets or sets the paid date.
        /// </summary>
        /// <value>
        /// The paid date.
        /// </value>
        public virtual DateTime PaidDate { get; set; }
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
        /// Gets or sets the sum total price.
        /// </summary>
        /// <value>
        /// The sum total price.
        /// </value>
        public virtual Decimal SumTotalPrice { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public virtual Currency Currency { get; set; }
        /// <summary>
        /// Gets or sets the invoice adress.
        /// </summary>
        /// <value>
        /// The invoice adress.
        /// </value>
        public virtual Adress InvoiceAdress { get; set; }
        /// <summary>
        /// Gets or sets the invoice status.
        /// </summary>
        /// <value>
        /// The invoice status.
        /// </value>
        public virtual InvoiceStatus InvoiceStatus { get; set; }
        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public virtual PaymentStatus PaymentStatus { get; set; }
        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        public virtual IList<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Label;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Invoice invoice;
            try
            {
                invoice = (Invoice)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (InvoiceId != invoice.InvoiceId)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.InvoiceId;
        }

    }
}