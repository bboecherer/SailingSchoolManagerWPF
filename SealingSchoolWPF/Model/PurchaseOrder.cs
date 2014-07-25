using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The PurchaseOrder Model
    /// </summary>
    public class PurchaseOrder : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the purchase order identifier.
        /// </summary>
        /// <value>
        /// The purchase order identifier.
        /// </value>
        [Key]
        public int PurchaseOrderId { get; set; }
    }
}
