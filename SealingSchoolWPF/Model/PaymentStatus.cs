using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    ///  The PaymentStatus Enum
    ///  @Author Benjamin Böcherer
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// useable values are NICHT_GEZAHLT, GEZAHLT, TEILW_GEZAHLT, GUTGESCHRIEBEN, MEHR_GEZAHLT
        /// </summary>
        NICHT_GEZAHLT, GEZAHLT, TEILW_GEZAHLT, GUTGESCHRIEBEN, MEHR_GEZAHLT
    }
}