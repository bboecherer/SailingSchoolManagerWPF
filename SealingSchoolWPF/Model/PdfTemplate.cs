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
        public int id;

        // Der Inhalt des pdf-Dokumentes in Form einer XHTML-Datei mit Platzhaltern
        public String xhtmlTemplate;

        // public TemplateType type;
    }
}
