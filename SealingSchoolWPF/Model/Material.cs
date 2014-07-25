using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    ///  The Material Model
    /// </summary>
    public class Material : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the material identifier.
        /// </summary>
        /// <value>
        /// The material identifier.
        /// </value>
        [Key]
        public virtual int MaterialId { get; set; }
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
        /// Gets or sets the material typ.
        /// </summary>
        /// <value>
        /// The material typ.
        /// </value>
        public virtual MaterialTyp MaterialTyp { get; set; }
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
        /// Gets or sets the boat typs.
        /// </summary>
        /// <value>
        /// The boat typs.
        /// </value>
        [InverseProperty("Material")]
        public virtual ICollection<BoatTyp> BoatTyps { get; set; }



    }
}
