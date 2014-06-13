using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class BankAccountData
    {
        [Key]
        public virtual int BankId { get; set; }
        public virtual string BankNo { get; set; }
        public virtual string BankName { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Bic { get; set; }
        public virtual string Iban { get; set; }
        public virtual bool Sepa { get; set; }

    }
}
