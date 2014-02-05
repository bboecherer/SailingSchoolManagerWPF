using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace De.SealingSchoolManager.Model
{
    public class Student : SealingSchoolObject, IDataErrorInfo, IAddressable
    {

        public static Student CreateNewStudent()
        {
            return new Student();
        }

        public static Student CreateStudent(
            string firstName,
            string lastName,
            string label)
        {
            return new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Label = label
            };
        }

        protected Student()
        {
        }


        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }


        public override string ToString()
        {
            return "Teilnehmer: " + this.Label;
        }



        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }


        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
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

        static readonly string[] ValidatedProperties = 
        { 
            "Label", 
            "FirstName", 
            "LastName",
        };

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
                    Debug.Fail("Unexpected property being validated on Student: " + propertyName);
                    break;
            }

            return error;
        }

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

        string ValidateFirstName()
        {
            if (IsStringMissing(this.FirstName))
            {
                return "";//Strings.Customer_Error_MissingFirstName;
            }
            return null;
        }

        string ValidateLastName()
        {

            if (IsStringMissing(this.LastName))
            {
                return "";//Strings.Customer_Error_MissingFirstName;
            }
            return null;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

    }
}