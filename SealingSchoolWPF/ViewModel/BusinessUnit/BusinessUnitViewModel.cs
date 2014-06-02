using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SealingSchoolWPF.Model;

namespace SealingSchoolWPF.ViewModel.BusinessUnit
{
    public class BusinessUnitViewModel : ViewModel<SealingSchoolWPF.Model.BusinessUnit>
    {

        #region Ctor
        public BusinessUnitViewModel(SealingSchoolWPF.Model.BusinessUnit model)
            : base(model)
        {
        }

        static BusinessUnitViewModel instance = null;
        static readonly object padlock = new object();

        public static BusinessUnitViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BusinessUnitViewModel(new SealingSchoolWPF.Model.BusinessUnit());
                    }
                    return instance;
                }
            }
        }
        #endregion

        private static BusinessUnitMgr mgr = new BusinessUnitMgr();
        private static SealingSchoolWPF.Model.BusinessUnit bu = mgr.GetBu();

        #region properties
        public string Label
        {
            get
            {
                return bu.Label;
            }
            set
            {
                if (Label != value)
                {
                    bu.Label = value;

                }
            }
        }

        // Email Adress des Admin Accounts
        public String AdminEmail
        {
            get
            {
                return bu.adminEmail;
            }
            set
            {
                if (AdminEmail != value)
                {
                    bu.adminEmail = value;

                }
            }
        }

        // Name der Geschäftseinheit nach "aussen", z.B. Rechnungsstellung
        public String ExternalLabel
        {
            get
            {
                return bu.externalLabel;
            }
            set
            {
                if (ExternalLabel != value)
                {
                    bu.externalLabel = value;

                }
            }
        }

        public String CustomField1Alias
        {
            get
            {
                return bu.customField1Alias;
            }
            set
            {
                if (CustomField1Alias != value)
                {
                    bu.customField1Alias = value;

                }
            }
        }

        public String CustomField2Alias
        {
            get
            {
                return bu.customField2Alias;
            }
            set
            {
                if (CustomField2Alias != value)
                {
                    bu.customField2Alias = value;

                }
            }
        }

        public String CustomField3Alias
        {
            get
            {
                return bu.customField3Alias;
            }
            set
            {
                if (CustomField3Alias != value)
                {
                    bu.customField3Alias = value;

                }
            }
        }

        public String CustomField4Alias
        {
            get
            {
                return bu.customField4Alias;
            }
            set
            {
                if (CustomField4Alias != value)
                {
                    bu.customField4Alias = value;

                }
            }
        }

        public String Email
        {
            get
            {
                return bu.email;
            }
            set
            {
                if (Email != value)
                {
                    bu.email = value;

                }
            }
        }

        public String Tel1
        {
            get
            {
                return bu.tel1;
            }
            set
            {
                if (Tel1 != value)
                {
                    bu.tel1 = value;

                }
            }
        }

        public String Fax1
        {
            get
            {
                return bu.fax1;
            }
            set
            {
                if (Fax1 != value)
                {
                    bu.fax1 = value;

                }
            }
        }

        public String Tel2
        {
            get
            {
                return bu.tel2;
            }
            set
            {
                if (Tel2 != value)
                {
                    bu.tel2 = value;

                }
            }
        }

        public String Fax2
        {
            get
            {
                return bu.fax2;
            }
            set
            {
                if (Fax2 != value)
                {
                    bu.fax2 = value;

                }
            }
        }

        public String AddressLine1
        {
            get
            {
                return bu.addressLine1;
            }
            set
            {
                if (AddressLine1 != value)
                {
                    bu.addressLine1 = value;

                }
            }
        }

        public String AddressLine2
        {
            get
            {
                return bu.addressLine2;
            }
            set
            {
                if (AddressLine2 != value)
                {
                    bu.addressLine2 = value;

                }
            }
        }

        public String AddressLine3
        {
            get
            {
                return bu.addressLine3;
            }
            set
            {
                if (AddressLine3 != value)
                {
                    bu.addressLine3 = value;

                }
            }
        }

        public String ZipCode
        {
            get
            {
                return bu.zipCode;
            }
            set
            {
                if (ZipCode != value)
                {
                    bu.zipCode = value;

                }
            }
        }

        public String City
        {
            get
            {
                return bu.city;
            }
            set
            {
                if (City != value)
                {
                    bu.city = value;

                }
            }
        }

        public String Country
        {
            get
            {
                return bu.country;
            }
            set
            {
                if (Country != value)
                {
                    bu.country = value;

                }
            }
        }

        public String State
        {
            get
            {
                return bu.state;
            }
            set
            {
                if (State != value)
                {
                    bu.state = value;

                }
            }
        }

        public String Website
        {
            get
            {
                return bu.website;
            }
            set
            {
                if (Website != value)
                {
                    bu.website = value;

                }
            }
        }


        public DateTime FiscalYearBegin
        {
            get
            {
                return bu.fiscalYearBegin;
            }
            set
            {
                if (FiscalYearBegin != value)
                {
                    bu.fiscalYearBegin = value;

                }
            }
        }

        public Currency BaseCurrency
        {
            get
            {
                return bu.baseCurrency;
            }
            set
            {
                if (BaseCurrency != value)
                {
                    bu.baseCurrency = value;

                }
            }
        }


        public String InvoicePrefix
        {
            get
            {
                return bu.invoicePrefix;
            }
            set
            {
                if (InvoicePrefix != value)
                {
                    bu.invoicePrefix = value;

                }
            }
        }


        public int DefaultPaymentDeadline
        {
            get
            {
                return bu.defaultPaymentDeadline;
            }
            set
            {
                if (DefaultPaymentDeadline != value)
                {
                    bu.defaultPaymentDeadline = value;

                }
            }
        }

        // Bankinstitut
        public String BankName
        {
            get
            {
                return bu.bankName;
            }
            set
            {
                if (BankName != value)
                {
                    bu.bankName = value;

                }
            }
        }

        // Kontonummer
        public String BankAccountNo
        {
            get
            {
                return bu.bankAccountNo;
            }
            set
            {
                if (BankAccountNo != value)
                {
                    bu.bankAccountNo = value;

                }
            }
        }

        // z.B. Steuernummer oder Firmenbuch
        public String CountrySpec1
        {
            get
            {
                return bu.countrySpec1;
            }
            set
            {
                if (CountrySpec1 != value)
                {
                    bu.countrySpec1 = value;

                }
            }
        }

        // z.B. DVR
        public String CountrySpec2
        {
            get
            {
                return bu.countrySpec2;
            }
            set
            {
                if (CountrySpec2 != value)
                {
                    bu.countrySpec2 = value;

                }
            }
        }

        // USt Nr in dem aktuellen Land
        public String VatId
        {
            get
            {
                return bu.vatId;
            }
            set
            {
                if (VatId != value)
                {
                    bu.vatId = value;

                }
            }
        }

        // Kontoinhaber
        public String BankAccountName
        {
            get
            {
                return bu.bankAccountName;
            }
            set
            {
                if (BankAccountName != value)
                {
                    bu.bankAccountName = value;

                }
            }
        }

        // BLZ
        public String BankNo
        {
            get
            {
                return bu.bankNo;
            }
            set
            {
                if (BankNo != value)
                {
                    bu.bankNo = value;

                }
            }
        }

        // IBAN
        public String Iban
        {
            get
            {
                return bu.iban;
            }
            set
            {
                if (Iban != value)
                {
                    bu.iban = value;

                }
            }
        }

        // SWIFT
        public String Swift
        {
            get
            {
                return bu.swift;
            }
            set
            {
                if (Swift != value)
                {
                    bu.swift = value;

                }
            }
        }
        #endregion
    }
}