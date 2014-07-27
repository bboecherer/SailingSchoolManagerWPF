using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The ContactData Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public class ContactData
    {
        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        [Key]
        public virtual int ContactId { get; set; }
        /// <summary>
        /// Gets or sets the tel1.
        /// </summary>
        /// <value>
        /// The tel1.
        /// </value>
        public virtual string Tel1 { get; set; }
        /// <summary>
        /// Gets or sets the tel2.
        /// </summary>
        /// <value>
        /// The tel2.
        /// </value>
        public virtual string Tel2 { get; set; }
        /// <summary>
        /// Gets or sets the tel3.
        /// </summary>
        /// <value>
        /// The tel3.
        /// </value>
        public virtual string Tel3 { get; set; }
        /// <summary>
        /// Gets or sets the fax1.
        /// </summary>
        /// <value>
        /// The fax1.
        /// </value>
        public virtual string Fax1 { get; set; }
        /// <summary>
        /// Gets or sets the fax2.
        /// </summary>
        /// <value>
        /// The fax2.
        /// </value>
        public virtual string Fax2 { get; set; }
        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>
        /// The web site.
        /// </value>
        public virtual string WebSite { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public virtual string Email { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [wants email notification].
        /// </summary>
        /// <value>
        /// <c>true</c> if [wants email notification]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool WantsEmailNotification { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [wants tel notification].
        /// </summary>
        /// <value>
        /// <c>true</c> if [wants tel notification]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool WantsTelNotification { get; set; }

    }
}
