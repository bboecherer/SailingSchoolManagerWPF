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
    /// The BlockedTimeSpan Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class BlockedTimeSpan
    {
        /// <summary>
        /// Gets or sets the blocked time span identifier.
        /// </summary>
        /// <value>
        /// The blocked time span identifier.
        /// </value>
        [Key]
        public virtual int BlockedTimeSpanId { get; set; }
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
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public virtual Course Course { get; set; }

        /// <summary>
        /// Gets or sets the instructor.
        /// </summary>
        /// <value>
        /// The instructor.
        /// </value>
        public virtual Instructor Instructor { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public virtual String Reason { get; set; }


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

            if (this.Course != null)
            {
                builder.Append(string.Format(", Kurs {0}", this.Course.Label));
            }
            else
            {
                builder.Append(", privat");

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
            BlockedTimeSpan blocked;
            try
            {
                blocked = (BlockedTimeSpan)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (BlockedTimeSpanId != blocked.BlockedTimeSpanId)
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
            return base.GetHashCode() ^ this.BlockedTimeSpanId;
        }
    }
}
