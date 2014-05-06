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
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Adress Adress { get; set; }

        public ContactData Contact { get; set; }

        public BankAccountData Bank { get; set; }

        public bool SSS { get; set; }

        public DateTime SSSDate { get; set; }

        public bool SKS { get; set; }

        public DateTime SKSDate { get; set; }

        public bool SBFSEA { get; set; }

        public DateTime SBFSEADate { get; set; }

        public bool SBFBINNEN { get; set; }

        public DateTime SBFBINNENDate { get; set; }

        public bool SRC { get; set; }

        public DateTime SRCDate { get; set; }

        public bool UBI { get; set; }

        public DateTime UBIDate { get; set; }

        public bool DSV { get; set; }

        public DateTime DSVDate { get; set; }

        public bool SHS { get; set; }

        public DateTime SHSDate { get; set; }

        public bool LifeGuard { get; set; }

        public DateTime LifeGuardDate { get; set; }

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
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
