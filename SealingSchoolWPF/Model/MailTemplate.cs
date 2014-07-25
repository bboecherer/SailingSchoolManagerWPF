using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The MailTemplate Model
    /// </summary>
    public class MailTemplate
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        // Der Sender einer Email
        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public String Sender { get; set; }

        // Betreff einer EMail mit Platzhaltern
        /// <summary>
        /// Gets or sets the subject template.
        /// </summary>
        /// <value>
        /// The subject template.
        /// </value>
        public String SubjectTemplate { get; set; }

        // Der Inhalt der Email mit Platzhaltern
        /// <summary>
        /// Gets or sets the body template.
        /// </summary>
        /// <value>
        /// The body template.
        /// </value>
        public String BodyTemplate { get; set; }

        //public TemplateType type;
    }
}
