using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Instructor : SealingSchoolObject, IDataErrorInfo
    {
        [Key]
        public virtual int InstructorId { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual ContactData Contact { get; set; }
        public virtual BankAccountData Bank { get; set; }
        public Decimal HonorarValueDay { get; set; }
        public Decimal HonorarValueStd { get; set; }
        public virtual IList<Qualification> Qualifications { get; set; }

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public override bool Equals(object obj)
        {
            Instructor instr = (Instructor)obj;

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

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.InstructorId;
        }

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
                    Debug.Fail("Unexpected property being validated on Instructor: " + propertyName);
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
