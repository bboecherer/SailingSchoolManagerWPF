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
    /// The Course Model
    /// </summary>
    public class Course : SealingSchoolObject
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>
        /// The course identifier.
        /// </value>
        [Key]
        public virtual int CourseId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public virtual string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }
        /// <summary>
        /// Gets or sets the net price.
        /// </summary>
        /// <value>
        /// The net price.
        /// </value>
        public virtual Decimal NetPrice { get; set; }
        /// <summary>
        /// Gets or sets the gross price.
        /// </summary>
        /// <value>
        /// The gross price.
        /// </value>
        public virtual Decimal GrossPrice { get; set; }
        /// <summary>
        /// Gets or sets the net amount.
        /// </summary>
        /// <value>
        /// The net amount.
        /// </value>
        public virtual Decimal NetAmount { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public virtual int Duration { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public virtual Currency Currency { get; set; }
        /// <summary>
        /// Gets or sets the course status.
        /// </summary>
        /// <value>
        /// The course status.
        /// </value>
        public virtual CourseStatus CourseStatus { get; set; }
        /// <summary>
        /// Gets or sets the credits.
        /// </summary>
        /// <value>
        /// The credits.
        /// </value>
        public virtual int Credits { get; set; }
        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public virtual int Capacity { get; set; }
        /// <summary>
        /// Gets or sets the needed instructors.
        /// </summary>
        /// <value>
        /// The needed instructors.
        /// </value>
        public virtual int NeededInstructors { get; set; }
        /// <summary>
        /// Gets or sets the rating value.
        /// </summary>
        /// <value>
        /// The rating value.
        /// </value>
        public virtual Double RatingValue { get; set; }
        /// <summary>
        /// Gets or sets the course material typs.
        /// </summary>
        /// <value>
        /// The course material typs.
        /// </value>
        public virtual ICollection<CourseMaterialTyp> CourseMaterialTyps { get; set; }
        /// <summary>
        /// Gets or sets the boat typ.
        /// </summary>
        /// <value>
        /// The boat typ.
        /// </value>
        public virtual BoatTyp BoatTyp { get; set; }


        /// <summary>
        /// Gets or sets the qualifications.
        /// </summary>
        /// <value>
        /// The qualifications.
        /// </value>
        [InverseProperty("Courses")]
        public virtual ICollection<Qualification> Qualifications { get; set; }

        /// <summary>
        /// Gets or sets the course planings.
        /// </summary>
        /// <value>
        /// The course planings.
        /// </value>
        [InverseProperty("Course")]
        public virtual ICollection<CoursePlaning> CoursePlanings { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Course course;
            try
            {
                course = (Course)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (CourseId != course.CourseId)
            {
                return false;
            }

            if (Label != course.Label)
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
            return base.GetHashCode() ^ this.CourseId;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Label;
        }

    }
}