using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The Grade Enum
    /// @Author Benjamin Böcherer
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// useable values are RECHNUNG, ERSTE_MAHNUNG, ZWEITE_MAHNUNG, DRITTE_MAHNUNG, CANCELLED, GUTSCHRIFT
        /// </summary>
        RECHNUNG, ERSTE_MAHNUNG, ZWEITE_MAHNUNG, DRITTE_MAHNUNG, CANCELLED, GUTSCHRIFT
    }
}