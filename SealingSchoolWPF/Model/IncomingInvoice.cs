using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The IncomingInvoice Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class IncomingInvoice : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the incoming invoice identifier.
        /// </summary>
        /// <value>
        /// The incoming invoice identifier.
        /// </value>
        [Key]
        public int IncomingInvoiceId { get; set; }
    }
}
