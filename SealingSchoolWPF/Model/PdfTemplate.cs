using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class PdfTemplate
    {
        [Key]
        public int Id { get; set; }

        // Der Inhalt des pdf-Dokumentes in Form einer XHTML-Datei mit Platzhaltern
        public String XhtmlTemplate { get; set; }

        // public TemplateType type;
    }
}
