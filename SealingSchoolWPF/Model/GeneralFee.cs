using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The GeneralFee Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class GeneralFee
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        // Der nominale Nettobetrag in der Standardwährung, der erhoben werden darf
        /// <summary>
        /// Gets or sets the net price.
        /// </summary>
        /// <value>
        /// The net price.
        /// </value>
        public Decimal NetPrice { get; set; }

        // Der Mehrwertsteuersatz, der auf den angegebenen Nettobetrag gerechnet wird.
        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>
        /// The percentage.
        /// </value>
        public Double Percentage { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public String Label { get; set; }

        // Der nominale Bruttobetrag in der Standardwährung, der erhoben werden darf
        /// <summary>
        /// Gets or sets the gross price.
        /// </summary>
        /// <value>
        /// The gross price.
        /// </value>
        public Decimal GrossPrice { get; set; }

        // Das Datum des Inkrafttretens
        /// <summary>
        /// Gets or sets the valid from.
        /// </summary>
        /// <value>
        /// The valid from.
        /// </value>
        public DateTime ValidFrom { get; set; }
    }
}
