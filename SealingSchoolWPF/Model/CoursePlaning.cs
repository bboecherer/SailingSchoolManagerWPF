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
    /// The CoursePlaning Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CoursePlaning : SealingSchoolObject
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        /// <summary>
        /// Gets or sets the course planing identifier.
        /// </summary>
        /// <value>
        /// The course planing identifier.
        /// </value>
        [Key]
        public virtual int CoursePlaningId { get; set; }
        /// <summary>
        /// Gets or sets the course status.
        /// </summary>
        /// <value>
        /// The course status.
        /// </value>
        public virtual CourseStatus CourseStatus { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public virtual DateTime? StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public virtual DateTime? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the blocked material.
        /// </summary>
        /// <value>
        /// The blocked material.
        /// </value>
        public virtual ICollection<BlockedMaterial> BlockedMaterial { get; set; }
        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public virtual Course Course { get; set; }

        /// <summary>
        /// Gets or sets the instructors.
        /// </summary>
        /// <value>
        /// The instructors.
        /// </value>
        [InverseProperty("CoursePlanings")]
        public virtual ICollection<Instructor> Instructors { get; set; }


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            CoursePlaning Course;
            try
            {
                Course = (CoursePlaning)obj;
            }
            catch (Exception)
            {
                return false;
            }


            if (CoursePlaningId != Course.CoursePlaningId)
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
            return base.GetHashCode() ^ this.CoursePlaningId;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Label + " (" + this.StartDate + " - " + this.EndDate + ")";
        }
    }
}