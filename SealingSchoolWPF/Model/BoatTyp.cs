using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The BoatTyp Model
    /// @Author Stefan Müller
    /// </summary>
    public class BoatTyp : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the boat typ identifier.
        /// </summary>
        /// <value>
        /// The boat typ identifier.
        /// </value>
        [Key]
        public virtual int BoatTypID { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }
        /// <summary>
        /// Gets or sets the crew amount.
        /// </summary>
        /// <value>
        /// The crew amount.
        /// </value>
        public virtual int CrewAmount { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual String Description { get; set; }

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>
        /// The material.
        /// </value>
        public virtual ICollection<Material> Material { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                BoatTyp boatTyp = (BoatTyp)obj;


                if (BoatTypID != boatTyp.BoatTypID)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.BoatTypID;
        }
    }
}
