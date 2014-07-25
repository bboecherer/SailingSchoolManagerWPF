using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The TrainingActivity Model
    /// </summary>
    public class TrainingActivity : SealingSchoolObject
    {

        /// <summary>
        /// Gets or sets the training activity identifier.
        /// </summary>
        /// <value>
        /// The training activity identifier.
        /// </value>
        [Key]
        public virtual int TrainingActivityId { get; set; }
        /// <summary>
        /// Gets or sets the gross price org.
        /// </summary>
        /// <value>
        /// The gross price org.
        /// </value>
        public virtual Decimal GrossPriceOrg { get; set; }
        /// <summary>
        /// Gets or sets the net price org.
        /// </summary>
        /// <value>
        /// The net price org.
        /// </value>
        public virtual Decimal NetPriceOrg { get; set; }
        /// <summary>
        /// Gets or sets the vat amount org.
        /// </summary>
        /// <value>
        /// The vat amount org.
        /// </value>
        public virtual Decimal VatAmountOrg { get; set; }
        /// <summary>
        /// Gets or sets the reg date time.
        /// </summary>
        /// <value>
        /// The reg date time.
        /// </value>
        public virtual DateTime? RegDateTime { get; set; }
        /// <summary>
        /// Gets or sets the cancel date time.
        /// </summary>
        /// <value>
        /// The cancel date time.
        /// </value>
        public virtual DateTime? CancelDateTime { get; set; }
        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        /// <value>
        /// The start date time.
        /// </value>
        public virtual DateTime? StartDateTime { get; set; }
        /// <summary>
        /// Gets or sets the training activity status.
        /// </summary>
        /// <value>
        /// The training activity status.
        /// </value>
        public virtual TrainingActivityStatus TrainingActivityStatus { get; set; }
        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        public virtual Student Student { get; set; }
        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public virtual Course Course { get; set; }
        /// <summary>
        /// Gets or sets the course planing.
        /// </summary>
        /// <value>
        /// The course planing.
        /// </value>
        public virtual CoursePlaning CoursePlaning { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Label;
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
            TrainingActivity ta;
            try
            {
                ta = (TrainingActivity)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (TrainingActivityId != ta.TrainingActivityId)
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
            return base.GetHashCode() ^ this.TrainingActivityId;
        }
    }
}
