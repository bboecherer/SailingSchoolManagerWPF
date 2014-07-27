using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The Boat Model
    /// @Author Stefan Müller
    /// </summary>
    public class Boat : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the boat identifier.
        /// </summary>
        /// <value>
        /// The boat identifier.
        /// </value>
        [Key]
        public virtual int BoatID { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }
        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        /// <value>
        /// The brand.
        /// </value>
        public virtual string Brand { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public virtual Decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public virtual Currency Currency { get; set; }
        /// <summary>
        /// Gets or sets the material status.
        /// </summary>
        /// <value>
        /// The material status.
        /// </value>
        public virtual MaterialStatus MaterialStatus { get; set; }
        /// <summary>
        /// Gets or sets the repair action.
        /// </summary>
        /// <value>
        /// The repair action.
        /// </value>
        public virtual string RepairAction { get; set; }
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public virtual string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the boat typ.
        /// </summary>
        /// <value>
        /// The boat typ.
        /// </value>
        public virtual BoatTyp BoatTyp { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual String Description { get; set; }

        /// <summary>
        /// Gets or sets the course planing.
        /// </summary>
        /// <value>
        /// The course planing.
        /// </value>
        public virtual CoursePlaning CoursePlaning { get; set; }

    }
}
