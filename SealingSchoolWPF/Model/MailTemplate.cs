using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class MailTemplate
    {
        [Key]
        public int Id { get; set; }

        // Der Sender einer Email
        public String Sender { get; set; }

        // Betreff einer EMail mit Platzhaltern
        public String SubjectTemplate { get; set; }

        // Der Inhalt der Email mit Platzhaltern
        public String BodyTemplate { get; set; }

        //public TemplateType type;
    }
}
