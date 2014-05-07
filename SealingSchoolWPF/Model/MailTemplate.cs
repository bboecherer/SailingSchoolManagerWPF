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
        public int id;

        // Der Sender einer Email
        public String sender;

        // Betreff einer EMail mit Platzhaltern
        public String subjectTemplate;

        // Der Inhalt der Email mit Platzhaltern
        public String bodyTemplate;

        //public TemplateType type;
    }
}
