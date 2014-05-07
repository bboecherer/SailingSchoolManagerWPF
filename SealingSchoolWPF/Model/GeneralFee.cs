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
        public int id;

        // Der nominale Nettobetrag in der Standardwährung, der erhoben werden darf
        public Decimal netPrice;

        // Der Mehrwertsteuersatz, der auf den angegebenen Nettobetrag gerechnet wird.
        public Double percentage;

        public String label;

        // Der nominale Bruttobetrag in der Standardwährung, der erhoben werden darf
        public Decimal grossPrice;

        // Das Datum des Inkrafttretens
        public DateTime validFrom;
    }
}
