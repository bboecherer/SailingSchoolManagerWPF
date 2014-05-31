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
        public virtual int ContactId { get; set; }
        public virtual string Tel1 { get; set; }
        public virtual string Tel2 { get; set; }
        public virtual string Tel3 { get; set; }
        public virtual string Fax1 { get; set; }
        public virtual string Fax2 { get; set; }
        public virtual string WebSite { get; set; }
        public virtual string Email { get; set; }
        public virtual bool WantsEmailNotification { get; set; }
        public virtual bool WantsTelNotification { get; set; }

    }
}
