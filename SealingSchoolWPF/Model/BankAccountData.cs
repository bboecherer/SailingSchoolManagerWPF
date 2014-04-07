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
        public int BankId { get; set; }
        public string BankNo { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string Bic { get; set; }
        public string Iban { get; set; }
        public bool Sepa { get; set; }
    }
}
