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
    ///The BlockedMaterial Model
    ///@Author Stefan Müller
    /// </summary>
    public class BlockedMaterial
    {
        /// <summary>
        /// Gets or sets the blocked material identifier.
        /// </summary>
        /// <value>
        /// The blocked material identifier.
        /// </value>
        [Key]
        public virtual int BlockedMaterialId { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>
        /// The material.
        /// </value>
        public virtual Material Material { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Von " + StartDate.ToShortDateString() + " bis " + this.EndDate.ToShortDateString());

            if (this.Material != null)
            {
                builder.Append(string.Format(", Material {0}", this.Material.Label));
            }
            else
            {
                builder.Append("");

            }

            return builder.ToString();
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
            BlockedMaterial blocked;
            try
            {
                blocked = (BlockedMaterial)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (BlockedMaterialId != blocked.BlockedMaterialId)
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
            return base.GetHashCode() ^ this.BlockedMaterialId;
        }
    }
}
