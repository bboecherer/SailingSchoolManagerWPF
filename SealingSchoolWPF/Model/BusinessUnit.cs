using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class BusinessUnit : SealingSchoolObject
    {
        [Key]
        public string id { get; set; }

        // Die USt Sätze, die für diese Geschäftseinheit definiert werden. Diese
        // besitzen ein Gültigkeitsdatum, das angibt, ab wann der Ust Satz genutzt
        // werden soll.
        public HashSet<Vat> vats = new HashSet<Vat>();

        // Die Fee Sätze, die für diese Geschäftseinheit definiert werden. Diese
        // besitzen ein Gültigkeitsdatum, das angibt, ab wann der Satz genutzt werden
        // soll.
        public HashSet<Fee> accountingFees = new HashSet<Fee>();

        // Die Invoice Fee Sätze (Mahnungen), die für diese Geschäftseinheit definiert
        // werden. Diese besitzen ein Gültigkeitsdatum, das angibt, ab wann der Satz
        // genutzt werden soll.
        public HashSet<GeneralFee> generalFees = new HashSet<GeneralFee>();

        // Die Emailvorlagen, die für diese Geschäftseinheit definiert werden.
        public List<MailTemplate> mailTemplates = new List<MailTemplate>();

        // Die pdf-Vorlagen, die für diese Geschäftseinheit definiert werden.
        public List<PdfTemplate> pdfTemplates = new List<PdfTemplate>();

        // Email Adress des Admin Accounts
        public String adminEmail { get; set; }

        // Name der Geschäftseinheit nach "aussen", z.B. Rechnungsstellung
        public String externalLabel { get; set; }

        public String customField1Alias { get; set; }

        public String customField2Alias { get; set; }

        public String customField3Alias { get; set; }

        public String customField4Alias { get; set; }

        public String email { get; set; }

        public String tel1 { get; set; }

        public String fax1 { get; set; }

        public String tel2 { get; set; }

        public String fax2 { get; set; }

        public String addressLine1 { get; set; }

        public String addressLine2 { get; set; }

        public String addressLine3 { get; set; }

        public String zipCode { get; set; }

        public String city { get; set; }

        public String country { get; set; }

        public String state { get; set; }

        public String website { get; set; }

        // Der Beginn eines Fiskaljahres, dabei ist allerdings nur der Tag und Monat
        // relevant, nicht das Jahr.         
        public DateTime fiscalYearBegin { get; set; }

        // Referenz auf die Basiswährung, in die sämtliche Beträge intern umgerechnet
        // werden
        public Currency baseCurrency { get; set; }

        // Präfix für die Generierung der Rechnungsnummer
        public String invoicePrefix { get; set; }

        // Standard Zahlungsziel
        public int defaultPaymentDeadline { get; set; }

        // Bankinstitut
        public String bankName { get; set; }

        // Kontonummer
        public String bankAccountNo { get; set; }

        // z.B. Steuernummer oder Firmenbuch
        public String countrySpec1 { get; set; }

        // z.B. DVR
        public String countrySpec2 { get; set; }

        // USt Nr in dem aktuellen Land
        public String vatId { get; set; }

        // Kontoinhaber
        public String bankAccountName { get; set; }

        // BLZ
        public String bankNo { get; set; }

        // IBAN
        public String iban { get; set; }

        // SWIFT
        public String swift { get; set; }

    }
}
