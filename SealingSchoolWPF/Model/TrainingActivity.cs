using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class TrainingActivity : SealingSchoolObject
    {

        [Key]
        public int Id { get; set; }

        public Decimal grossPriceOrg { get; set; }

        /**
         * Der Betrag, der 1:1 aus der DateTimenbank importiert wird.
         */
        public Decimal importedPrice { get; set; }

        /**
         * Die Netto-Registrierungsgebühr als Nominalwert wie er vorgesehen ist. In
         * der Regel entspricht dies dem Wert regPrice. Da regPrice aber überschrieben
         * werden kann, signalisiert dieser Wert lediglich den
         * "vom System vorgegebenen" Preis.
         */
        public Decimal netPriceOrg { get; set; }

        /**
         * Die Rechungspositionen, die für diese TA erzeugt wurden.
         */
        public List<InvoiceItem> invoiceItems = new List<InvoiceItem>();

        /**
         * Die enthaltene Mehrwertsteuer der Registrierungsgebühr als Nominalwert wie
         * vorgesehen. In der Regel entspricht dies dem Wert vatAmount. Da regPrice
         * aber überschrieben werden kann, signalisiert dieser Wert lediglich den
         * "vom System vorgegebenen" enthaltenen MwSt Betrag.
         */
        public Decimal vatAmountOrg { get; set; }


        /**
         * Der Mehrwertsteuersatz, der auf den angegebenen Nettobetrag gerechnet wird.
         */
        public Double vatOrg { get; set; }

        /**
         * Wurde der originäre Registrierungspreis manuell geändert, ist hier der
         * Änderungsgrund hinterlegt.
         */
        public String grossPriceCorReason { get; set; }

        /**
         * Das Registrierungsdatum
         */
        public DateTime regDateTime { get; set; }

        /**
         * Das Stornierungsdatum, falls storniert
         */
        public DateTime cancelDateTime { get; set; }

        public Decimal discount { get; set; }

        /**
         * Das Fertigstellungsdatum, falls Online Training
         */
        public DateTime completionDateTime { get; set; }

        public DateTime startDateTime { get; set; }

        /**
         * Name des Kreditkarteninhabers, falls mit Kreditkarte gezahlt
         */
        public String ccCardholderName { get; set; }

        /**
         * Typ der Kreditkarte, falls mit Kreditkarte gezahlt
         */
        public String ccType { get; set; }

        /**
         * Typ der Zahlung
         */
        public String transactionType { get; set; }

        /**
         * Transaktions-ID, falls mit Kreditkarte gezahlt
         */
        public String ccTransactionId { get; set; }

        /**
         * Letzten 4 Stellen, falls mit Kreditkarte gezahlt
         */
        public String ccNumber { get; set; }

        /**
         * Marker, für ChargeBack
         */
        public Boolean chargeBack { get; set; }

    }
}
