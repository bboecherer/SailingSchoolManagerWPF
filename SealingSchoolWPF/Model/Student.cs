using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{

    /// <summary>
    /// The Student Model
    /// </summary>
    public class Student : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the student identifier.
        /// </summary>
        /// <value>
        /// The student identifier.
        /// </value>
        [Key]
        public virtual int StudentId { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public virtual string LastName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the adress.
        /// </summary>
        /// <value>
        /// The adress.
        /// </value>
        public virtual Adress Adress { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public virtual ContactData Contact { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>
        /// The bank.
        /// </value>
        public virtual BankAccountData Bank { get; set; }

        /// <summary>
        /// Gets or sets the qualifications.
        /// </summary>
        /// <value>
        /// The qualifications.
        /// </value>
        [InverseProperty("Students")]
        public virtual ICollection<Qualification> Qualifications { get; set; }

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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Student stud;

            try
            {
                stud = (Student)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (StudentId != stud.StudentId)
            {
                return false;
            }

            if (Label != stud.Label)
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
            return base.GetHashCode() ^ this.StudentId;
        }
    }
}