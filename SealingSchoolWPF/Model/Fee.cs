using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The Fee Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class Fee
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        //Das Datum des Inkrafttretens
        /// <summary>
        /// Gets or sets the valid from.
        /// </summary>
        /// <value>
        /// The valid from.
        /// </value>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>
        /// The percentage.
        /// </value>
        public Double Percentage { get; set; }
    }
}
