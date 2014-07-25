using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    /// <summary>
    /// The BusinessUnit Model
    /// </summary>
    public class BusinessUnit : SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public string id { get; set; }

        // Die USt Sätze, die für diese Geschäftseinheit definiert werden. Diese
        // besitzen ein Gültigkeitsdatum, das angibt, ab wann der Ust Satz genutzt
        // werden soll.
        /// <summary>
        /// The vats
        /// </summary>
        public HashSet<Vat> vats = new HashSet<Vat>();

        // Die Fee Sätze, die für diese Geschäftseinheit definiert werden. Diese
        // besitzen ein Gültigkeitsdatum, das angibt, ab wann der Satz genutzt werden
        // soll.
        /// <summary>
        /// The accounting fees
        /// </summary>
        public HashSet<Fee> accountingFees = new HashSet<Fee>();

        // Die Invoice Fee Sätze (Mahnungen), die für diese Geschäftseinheit definiert
        // werden. Diese besitzen ein Gültigkeitsdatum, das angibt, ab wann der Satz
        // genutzt werden soll.
        /// <summary>
        /// The general fees
        /// </summary>
        public HashSet<GeneralFee> generalFees = new HashSet<GeneralFee>();

        // Die Emailvorlagen, die für diese Geschäftseinheit definiert werden.
        /// <summary>
        /// The mail templates
        /// </summary>
        public List<MailTemplate> mailTemplates = new List<MailTemplate>();

        // Die pdf-Vorlagen, die für diese Geschäftseinheit definiert werden.
        /// <summary>
        /// The PDF templates
        /// </summary>
        public List<PdfTemplate> pdfTemplates = new List<PdfTemplate>();

        // Email Adress des Admin Accounts
        /// <summary>
        /// Gets or sets the admin email.
        /// </summary>
        /// <value>
        /// The admin email.
        /// </value>
        public String adminEmail { get; set; }

        // Name der Geschäftseinheit nach "aussen", z.B. Rechnungsstellung
        /// <summary>
        /// Gets or sets the external label.
        /// </summary>
        /// <value>
        /// The external label.
        /// </value>
        public String externalLabel { get; set; }

        /// <summary>
        /// Gets or sets the custom field1 alias.
        /// </summary>
        /// <value>
        /// The custom field1 alias.
        /// </value>
        public String customField1Alias { get; set; }

        /// <summary>
        /// Gets or sets the custom field2 alias.
        /// </summary>
        /// <value>
        /// The custom field2 alias.
        /// </value>
        public String customField2Alias { get; set; }

        /// <summary>
        /// Gets or sets the custom field3 alias.
        /// </summary>
        /// <value>
        /// The custom field3 alias.
        /// </value>
        public String customField3Alias { get; set; }

        /// <summary>
        /// Gets or sets the custom field4 alias.
        /// </summary>
        /// <value>
        /// The custom field4 alias.
        /// </value>
        public String customField4Alias { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public String email { get; set; }

        /// <summary>
        /// Gets or sets the tel1.
        /// </summary>
        /// <value>
        /// The tel1.
        /// </value>
        public String tel1 { get; set; }

        /// <summary>
        /// Gets or sets the fax1.
        /// </summary>
        /// <value>
        /// The fax1.
        /// </value>
        public String fax1 { get; set; }

        /// <summary>
        /// Gets or sets the tel2.
        /// </summary>
        /// <value>
        /// The tel2.
        /// </value>
        public String tel2 { get; set; }

        /// <summary>
        /// Gets or sets the fax2.
        /// </summary>
        /// <value>
        /// The fax2.
        /// </value>
        public String fax2 { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>
        /// The address line1.
        /// </value>
        public String addressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>
        /// The address line2.
        /// </value>
        public String addressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the address line3.
        /// </summary>
        /// <value>
        /// The address line3.
        /// </value>
        public String addressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public String zipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public String city { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public String country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public String state { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public String website { get; set; }

        // Der Beginn eines Fiskaljahres, dabei ist allerdings nur der Tag und Monat
        // relevant, nicht das Jahr.         
        /// <summary>
        /// Gets or sets the fiscal year begin.
        /// </summary>
        /// <value>
        /// The fiscal year begin.
        /// </value>
        public DateTime fiscalYearBegin { get; set; }

        // Referenz auf die Basiswährung, in die sämtliche Beträge intern umgerechnet
        // werden
        /// <summary>
        /// Gets or sets the base currency.
        /// </summary>
        /// <value>
        /// The base currency.
        /// </value>
        public Currency baseCurrency { get; set; }

        // Präfix für die Generierung der Rechnungsnummer
        /// <summary>
        /// Gets or sets the invoice prefix.
        /// </summary>
        /// <value>
        /// The invoice prefix.
        /// </value>
        public String invoicePrefix { get; set; }

        // Standard Zahlungsziel
        /// <summary>
        /// Gets or sets the default payment deadline.
        /// </summary>
        /// <value>
        /// The default payment deadline.
        /// </value>
        public int defaultPaymentDeadline { get; set; }

        // Bankinstitut
        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public String bankName { get; set; }

        // Kontonummer
        /// <summary>
        /// Gets or sets the bank account no.
        /// </summary>
        /// <value>
        /// The bank account no.
        /// </value>
        public String bankAccountNo { get; set; }

        // z.B. Steuernummer oder Firmenbuch
        /// <summary>
        /// Gets or sets the country spec1.
        /// </summary>
        /// <value>
        /// The country spec1.
        /// </value>
        public String countrySpec1 { get; set; }

        // z.B. DVR
        /// <summary>
        /// Gets or sets the country spec2.
        /// </summary>
        /// <value>
        /// The country spec2.
        /// </value>
        public String countrySpec2 { get; set; }

        // USt Nr in dem aktuellen Land
        /// <summary>
        /// Gets or sets the vat identifier.
        /// </summary>
        /// <value>
        /// The vat identifier.
        /// </value>
        public String vatId { get; set; }

        // Kontoinhaber
        /// <summary>
        /// Gets or sets the name of the bank account.
        /// </summary>
        /// <value>
        /// The name of the bank account.
        /// </value>
        public String bankAccountName { get; set; }

        // BLZ
        /// <summary>
        /// Gets or sets the bank no.
        /// </summary>
        /// <value>
        /// The bank no.
        /// </value>
        public String bankNo { get; set; }

        // IBAN
        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>
        /// The iban.
        /// </value>
        public String iban { get; set; }

        // SWIFT
        /// <summary>
        /// Gets or sets the swift.
        /// </summary>
        /// <value>
        /// The swift.
        /// </value>
        public String swift { get; set; }

    }
}
