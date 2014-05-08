using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class GeneralFee
    {
        [Key]
        public int Id { get; set; }

        // Der nominale Nettobetrag in der Standardwährung, der erhoben werden darf
        public Decimal NetPrice { get; set; }

        // Der Mehrwertsteuersatz, der auf den angegebenen Nettobetrag gerechnet wird.
        public Double Percentage { get; set; }

        public String Label { get; set; }

        // Der nominale Bruttobetrag in der Standardwährung, der erhoben werden darf
        public Decimal GrossPrice { get; set; }

        // Das Datum des Inkrafttretens
        public DateTime ValidFrom { get; set; }
    }
}
