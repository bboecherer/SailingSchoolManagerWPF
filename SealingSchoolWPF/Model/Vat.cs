using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Vat
    {
        [Key]
        public int id { get; set; }

        //Das Datum des Inkrafttretens
        public DateTime validFrom { get; set; }

        //Der Mehrwertsteuersatz, der auf den angegebenen Nettobetrag gerechnet wird.
        public Double percentage { get; set; }

    }
}
