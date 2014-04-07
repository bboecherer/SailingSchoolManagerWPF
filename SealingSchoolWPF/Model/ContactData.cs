using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class ContactData
    {
        [Key]
        public int ContactId { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public bool WantsEmailNotification { get; set; }
        public bool WantsTelNotification { get; set; }

    }
}
