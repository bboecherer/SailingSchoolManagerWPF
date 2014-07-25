using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The Enrollment Model
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// Gets or sets the enrollment identifier.
        /// </summary>
        /// <value>
        /// The enrollment identifier.
        /// </value>
        public int EnrollmentId { get; set; }
        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>
        /// The course identifier.
        /// </value>
        public int CourseId { get; set; }
        /// <summary>
        /// Gets or sets the student identifier.
        /// </summary>
        /// <value>
        /// The student identifier.
        /// </value>
        public int StudentId { get; set; }
        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public Grade? Grade { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public virtual Course Course { get; set; }
        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        public virtual Student Student { get; set; }
    }
}