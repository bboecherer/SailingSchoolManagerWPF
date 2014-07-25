using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The BankAccountData Model
    /// </summary>
    public class BankAccountData
    {
        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        [Key]
        public virtual int BankId { get; set; }
        /// <summary>
        /// Gets or sets the bank no.
        /// </summary>
        /// <value>
        /// The bank no.
        /// </value>
        public virtual string BankNo { get; set; }
        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public virtual string BankName { get; set; }
        /// <summary>
        /// Gets or sets the account no.
        /// </summary>
        /// <value>
        /// The account no.
        /// </value>
        public virtual string AccountNo { get; set; }
        /// <summary>
        /// Gets or sets the bic.
        /// </summary>
        /// <value>
        /// The bic.
        /// </value>
        public virtual string Bic { get; set; }
        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>
        /// The iban.
        /// </value>
        public virtual string Iban { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BankAccountData"/> is sepa.
        /// </summary>
        /// <value>
        ///   <c>true</c> if sepa; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Sepa { get; set; }

    }
}
