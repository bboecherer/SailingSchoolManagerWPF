using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.ViewModel.BusinessUnit
{
    public class BusinessUnitViewModel : ViewModel<SealingSchoolWPF.Model.BusinessUnit>
    {
        public BusinessUnitViewModel(SealingSchoolWPF.Model.BusinessUnit model)
            : base(model)
        {
        }

        public string Label
        {
            get
            {
                return Model.Label;
            }
            set
            {
                if (Label != value)
                {
                    Model.Label = value;
                    this.OnPropertyChanged("Label");
                }
            }
        }

        // Email Adress des Admin Accounts
        public String adminEmail
        {
            get
            {
                return Model.adminEmail;
            }
            set
            {
                if (adminEmail != value)
                {
                    Model.adminEmail = value;
                    this.OnPropertyChanged("AdminEmail");
                }
            }
        }

        // Name der Geschäftseinheit nach "aussen", z.B. Rechnungsstellung
        public String externalLabel
        {
            get
            {
                return Model.externalLabel;
            }
            set
            {
                if (externalLabel != value)
                {
                    Model.externalLabel = value;
                    this.OnPropertyChanged("ExternalLabel");
                }
            }
        }

        public String customField1Alias
        {
            get
            {
                return Model.customField1Alias;
            }
            set
            {
                if (customField1Alias != value)
                {
                    Model.customField1Alias = value;
                    this.OnPropertyChanged("CustomField1Alias");
                }
            }
        }

        public String customField2Alias
        {
            get
            {
                return Model.customField2Alias;
            }
            set
            {
                if (customField2Alias != value)
                {
                    Model.customField2Alias = value;
                    this.OnPropertyChanged("CustomField2Alias");
                }
            }
        }

        public String customField3Alias
        {
            get
            {
                return Model.customField3Alias;
            }
            set
            {
                if (customField3Alias != value)
                {
                    Model.customField3Alias = value;
                    this.OnPropertyChanged("CustomField3Alias");
                }
            }
        }

        public String customField4Alias
        {
            get
            {
                return Model.customField4Alias;
            }
            set
            {
                if (customField4Alias != value)
                {
                    Model.customField4Alias = value;
                    this.OnPropertyChanged("CustomField4Alias");
                }
            }
        }

        public String email
        {
            get
            {
                return Model.email;
            }
            set
            {
                if (email != value)
                {
                    Model.email = value;
                    this.OnPropertyChanged("Email");
                }
            }
        }

        public String tel1
        {
            get
            {
                return Model.tel1;
            }
            set
            {
                if (tel1 != value)
                {
                    Model.tel1 = value;
                    this.OnPropertyChanged("Tel1");
                }
            }
        }

        public String fax1
        {
            get
            {
                return Model.fax1;
            }
            set
            {
                if (fax1 != value)
                {
                    Model.fax1 = value;
                    this.OnPropertyChanged("Fax1");
                }
            }
        }

        public String tel2
        {
            get
            {
                return Model.tel2;
            }
            set
            {
                if (tel2 != value)
                {
                    Model.tel2 = value;
                    this.OnPropertyChanged("Tel2");
                }
            }
        }

        public String fax2
        {
            get
            {
                return Model.fax2;
            }
            set
            {
                if (fax2 != value)
                {
                    Model.fax2 = value;
                    this.OnPropertyChanged("Fax2");
                }
            }
        }

        public String addressLine1
        {
            get
            {
                return Model.addressLine1;
            }
            set
            {
                if (addressLine1 != value)
                {
                    Model.addressLine1 = value;
                    this.OnPropertyChanged("AddressLine1");
                }
            }
        }

        public String addressLine2
        {
            get
            {
                return Model.addressLine2;
            }
            set
            {
                if (addressLine2 != value)
                {
                    Model.addressLine2 = value;
                    this.OnPropertyChanged("AddressLine2");
                }
            }
        }

        public String addressLine3
        {
            get
            {
                return Model.addressLine3;
            }
            set
            {
                if (addressLine3 != value)
                {
                    Model.addressLine3 = value;
                    this.OnPropertyChanged("AddressLine3");
                }
            }
        }

        public String zipCode
        {
            get
            {
                return Model.zipCode;
            }
            set
            {
                if (zipCode != value)
                {
                    Model.zipCode = value;
                    this.OnPropertyChanged("ZipCode");
                }
            }
        }

        public String city
        {
            get
            {
                return Model.city;
            }
            set
            {
                if (city != value)
                {
                    Model.city = value;
                    this.OnPropertyChanged("City");
                }
            }
        }

        public String country
        {
            get
            {
                return Model.country;
            }
            set
            {
                if (country != value)
                {
                    Model.country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        public String state
        {
            get
            {
                return Model.state;
            }
            set
            {
                if (state != value)
                {
                    Model.state = value;
                    this.OnPropertyChanged("State");
                }
            }
        }

        public String website
        {
            get
            {
                return Model.website;
            }
            set
            {
                if (website != value)
                {
                    Model.website = value;
                    this.OnPropertyChanged("Website");
                }
            }
        }


        public DateTime fiscalYearBegin
        {
            get
            {
                return Model.fiscalYearBegin;
            }
            set
            {
                if (fiscalYearBegin != value)
                {
                    Model.fiscalYearBegin = value;
                    this.OnPropertyChanged("FiscalYearBegin");
                }
            }
        }

        public Currency baseCurrency
        {
            get
            {
                return Model.baseCurrency;
            }
            set
            {
                if (baseCurrency != value)
                {
                    Model.baseCurrency = value;
                    this.OnPropertyChanged("BaseCurrency");
                }
            }
        }


        public String invoicePrefix
        {
            get
            {
                return Model.invoicePrefix;
            }
            set
            {
                if (invoicePrefix != value)
                {
                    Model.invoicePrefix = value;
                    this.OnPropertyChanged("InvoicePrefix");
                }
            }
        }


        public int defaultPaymentDeadline
        {
            get
            {
                return Model.defaultPaymentDeadline;
            }
            set
            {
                if (defaultPaymentDeadline != value)
                {
                    Model.defaultPaymentDeadline = value;
                    this.OnPropertyChanged("DefaultPaymentDeadline");
                }
            }
        }

        // Bankinstitut
        public String bankName
        {
            get
            {
                return Model.bankName;
            }
            set
            {
                if (bankName != value)
                {
                    Model.bankName = value;
                    this.OnPropertyChanged("bankName");
                }
            }
        }

        // Kontonummer
        public String bankAccountNo
        {
            get
            {
                return Model.bankAccountNo;
            }
            set
            {
                if (bankAccountNo != value)
                {
                    Model.bankAccountNo = value;
                    this.OnPropertyChanged("BankAccountNo");
                }
            }
        }

        // z.B. Steuernummer oder Firmenbuch
        public String countrySpec1
        {
            get
            {
                return Model.countrySpec1;
            }
            set
            {
                if (countrySpec1 != value)
                {
                    Model.countrySpec1 = value;
                    this.OnPropertyChanged("CountrySpec1");
                }
            }
        }

        // z.B. DVR
        public String countrySpec2
        {
            get
            {
                return Model.countrySpec2;
            }
            set
            {
                if (countrySpec2 != value)
                {
                    Model.countrySpec2 = value;
                    this.OnPropertyChanged("CountrySpec2");
                }
            }
        }

        // USt Nr in dem aktuellen Land
        public String vatId
        {
            get
            {
                return Model.vatId;
            }
            set
            {
                if (vatId != value)
                {
                    Model.vatId = value;
                    this.OnPropertyChanged("VatId");
                }
            }
        }

        // Kontoinhaber
        public String bankAccountName
        {
            get
            {
                return Model.bankAccountName;
            }
            set
            {
                if (bankAccountName != value)
                {
                    Model.bankAccountName = value;
                    this.OnPropertyChanged("BankAccountName");
                }
            }
        }

        // BLZ
        public String bankNo
        {
            get
            {
                return Model.bankNo;
            }
            set
            {
                if (bankNo != value)
                {
                    Model.bankNo = value;
                    this.OnPropertyChanged("BankNo");
                }
            }
        }

        // IBAN
        public String iban
        {
            get
            {
                return Model.iban;
            }
            set
            {
                if (iban != value)
                {
                    Model.iban = value;
                    this.OnPropertyChanged("Iban");
                }
            }
        }

        // SWIFT
        public String swift
        {
            get
            {
                return Model.swift;
            }
            set
            {
                if (swift != value)
                {
                    Model.swift = value;
                    this.OnPropertyChanged("Swift");
                }
            }
        }
    }
}