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
    /// The Instructor Model
    /// </summary>
    public class Instructor : SealingSchoolObject, IDataErrorInfo
    {
        /// <summary>
        /// Gets or sets the instructor identifier.
        /// </summary>
        /// <value>
        /// The instructor identifier.
        /// </value>
        [Key]
        public virtual int InstructorId { get; set; }
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
        /// Gets or sets the fee value day.
        /// </summary>
        /// <value>
        /// The fee value day.
        /// </value>
        public virtual Decimal FeeValueDay { get; set; }
        /// <summary>
        /// Gets or sets the fee value standard.
        /// </summary>
        /// <value>
        /// The fee value standard.
        /// </value>
        public virtual Decimal FeeValueStd { get; set; }
        /// <summary>
        /// Gets or sets the training activity.
        /// </summary>
        /// <value>
        /// The training activity.
        /// </value>
        public virtual TrainingActivity TrainingActivity { get; set; }
        /// <summary>
        /// Gets or sets the rating value.
        /// </summary>
        /// <value>
        /// The rating value.
        /// </value>
        public virtual Double RatingValue { get; set; }

        /// <summary>
        /// Gets or sets the qualifications.
        /// </summary>
        /// <value>
        /// The qualifications.
        /// </value>
        [InverseProperty("Instructors")]
        public virtual ICollection<Qualification> Qualifications { get; set; }

        /// <summary>
        /// Gets or sets the course planings.
        /// </summary>
        /// <value>
        /// The course planings.
        /// </value>
        [InverseProperty("Instructors")]
        public virtual ICollection<CoursePlaning> CoursePlanings { get; set; }

        /// <summary>
        /// Ruft eine Fehlermeldung ab, die den Fehler in diesem Objekt angibt.
        /// </summary>
        string IDataErrorInfo.Error { get { return null; } }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified property name.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
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
            Instructor instr;
            try
            {
                instr = (Instructor)obj;
            }
            catch (Exception)
            {
                return false;
            }

            if (InstructorId != instr.InstructorId)
            {
                return false;
            }

            if (Label != instr.Label)
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
            return base.GetHashCode() ^ this.InstructorId;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        /// <summary>
        /// The validated properties
        /// </summary>
        static readonly string[] ValidatedProperties = 
        { 
            "Label", 
            "FirstName", 
            "LastName",
        };

        /// <summary>
        /// Gets the validation error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Label":
                    error = this.ValidateLabel();
                    break;

                case "FirstName":
                    error = this.ValidateFirstName();
                    break;

                case "LastName":
                    error = this.ValidateLastName();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Instructor: " + propertyName);
                    break;
            }

            return error;
        }

        /// <summary>
        /// Validates the label.
        /// </summary>
        /// <returns></returns>
        string ValidateLabel()
        {
            if (IsStringMissing(this.Label))
            {
                return "";// Strings.Student_Error_MissingEmail;
            }
            else if (!IsValidEmailAddress(this.Label))
            {
                return "";//Strings.Customer_Error_InvalidEmail;
            }
            return null;
        }

        /// <summary>
        /// Validates the first name.
        /// </summary>
        /// <returns></returns>
        string ValidateFirstName()
        {
            if (IsStringMissing(this.FirstName))
            {
                return "";//Strings.Customer_Error_MissingFirstName;
            }
            return null;
        }

        /// <summary>
        /// Validates the last name.
        /// </summary>
        /// <returns></returns>
        string ValidateLastName()
        {

            if (IsStringMissing(this.LastName))
            {
                return "";//Strings.Customer_Error_MissingFirstName;
            }
            return null;
        }

        /// <summary>
        /// Determines whether [is string missing] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        /// <summary>
        /// Determines whether [is valid email address] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }

}
