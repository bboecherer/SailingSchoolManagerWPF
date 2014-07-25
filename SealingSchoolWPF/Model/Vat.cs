using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The Vat Model
    /// </summary>
    public class Vat
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int id { get; set; }

        //Das Datum des Inkrafttretens
        /// <summary>
        /// Gets or sets the valid from.
        /// </summary>
        /// <value>
        /// The valid from.
        /// </value>
        public DateTime validFrom { get; set; }

        //Der Mehrwertsteuersatz, der auf den angegebenen Nettobetrag gerechnet wird.
        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>
        /// The percentage.
        /// </value>
        public Double percentage { get; set; }

    }
}
