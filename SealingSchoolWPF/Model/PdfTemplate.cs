using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The PdfTemplate Model
    /// </summary>
    public class PdfTemplate
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        // Der Inhalt des pdf-Dokumentes in Form einer XHTML-Datei mit Platzhaltern
        /// <summary>
        /// Gets or sets the XHTML template.
        /// </summary>
        /// <value>
        /// The XHTML template.
        /// </value>
        public String XhtmlTemplate { get; set; }

        // public TemplateType type;
    }
}
