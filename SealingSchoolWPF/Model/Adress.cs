using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The Adress Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class Adress
    {
        /// <summary>
        /// Gets or sets the adress identifier.
        /// </summary>
        /// <value>
        /// The adress identifier.
        /// </value>
        [Key]
        public virtual int AdressId { get; set; }
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>
        /// The address line1.
        /// </value>
        public virtual string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>
        /// The address line2.
        /// </value>
        public virtual string AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the address line3.
        /// </summary>
        /// <value>
        /// The address line3.
        /// </value>
        public virtual string AddressLine3 { get; set; }
        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        public virtual string Street { get; set; }
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public virtual string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public virtual string City { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public virtual string Country { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public virtual string State { get; set; }

    }
}
