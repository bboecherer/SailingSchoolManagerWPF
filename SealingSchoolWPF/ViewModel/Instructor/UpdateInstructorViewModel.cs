using AS.IBAN;
using AS.IBAN.Helper;
using AS.IBAN.Model;
using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SealingSchoolWPF.ViewModel.InstructorViewModel
{
    public class UpdateInstructorViewModel : ViewModel<Model.Instructor>
    {
        public Model.Instructor InstructorDummy { get; set; }

        public UpdateInstructorViewModel(Model.Instructor model)
            : base(model)
        {
            instance = this;
            this.InstructorDummy = model;
        }

        static UpdateInstructorViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateInstructorViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateInstructorViewModel(new SealingSchoolWPF.Model.Instructor());
                    }
                    return instance;
                }
            }
        }

        InstructorMgr instructorMgr = new InstructorMgr();

        public string FirstName
        {
            get
            {
                return InstructorDummy.FirstName;
            }
            set
            {
                InstructorDummy.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return InstructorDummy.LastName;
            }
            set
            {
                InstructorDummy.LastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public string Street
        {
            get
            {
                return InstructorDummy.Adress.Street;
            }
            set
            {
                InstructorDummy.Adress.Street = value;
                this.OnPropertyChanged("Street");
            }
        }

        public string Postal
        {
            get
            {
                return InstructorDummy.Adress.ZipCode;
            }
            set
            {
                InstructorDummy.Adress.ZipCode = value;
                this.OnPropertyChanged("Postal");
            }
        }

        public string City
        {
            get
            {
                return InstructorDummy.Adress.City;
            }
            set
            {
                InstructorDummy.Adress.City = value;
                this.OnPropertyChanged("City");
            }
        }

        public string AccountNo
        {
            get
            {
                return InstructorDummy.Bank.AccountNo;
            }
            set
            {
                InstructorDummy.Bank.AccountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        public string BankNo
        {
            get
            {
                return InstructorDummy.Bank.BankNo;
            }
            set
            {
                InstructorDummy.Bank.BankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        public string BankName
        {
            get
            {
                return InstructorDummy.Bank.BankName;
            }
            set
            {
                InstructorDummy.Bank.BankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        public string Iban
        {
            get
            {
                return InstructorDummy.Bank.Iban;
            }
            set
            {
                InstructorDummy.Bank.Iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        public bool Sepa
        {
            get
            {
                return InstructorDummy.Bank.Sepa;
            }
            set
            {
                InstructorDummy.Bank.Sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        public string Bic
        {
            get
            {
                return InstructorDummy.Bank.Bic;
            }
            set
            {
                InstructorDummy.Bank.Bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        public string Notes
        {
            get
            {
                return InstructorDummy.AdditionalInfo;
            }
            set
            {
                InstructorDummy.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
            }
        }

        public Decimal HonorarValueStd
        {
            get
            {
                return InstructorDummy.HonorarValueStd;
            }
            set
            {
                InstructorDummy.HonorarValueStd= value;
                this.OnPropertyChanged("HonorarValueStd");
            }
        }

        public Decimal HonorarValueDay
        {
            get
            {
                return InstructorDummy.HonorarValueDay;
            }
            set
            {
                InstructorDummy.HonorarValueDay = value;
                this.OnPropertyChanged("HonorarValueDay");
            }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(p => ExecuteAddCommand());
                }
                return addCommand;
            }
        }

        public void Close()
        {
            instance = null;

        }

        private void ExecuteAddCommand()
        {
            Model.ModifiedOn = DateTime.Now;
            instructorMgr.Update(Model);
        }

        private ICommand generateBankData;
        public ICommand GenerateBankData
        {
            get
            {
                if (generateBankData == null)
                {
                    generateBankData = new RelayCommand(p => ExecuteBankCommand());
                }
                return generateBankData;
            }
        }

        private void ExecuteBankCommand()
        {
            try
            {
                this.BankName = GetGermanBank(this.BankNo, this.AccountNo);
                this.Iban = GenerateGermanIban(this.BankNo, this.AccountNo);
                this.Bic = GetGermanBic(this.Iban);
            }
            catch (Exception ex)
            {
                this.BankName = "Nicht gefunden";
                this.Iban = "Nicht gefunden";
                this.Bic = "Nicht gefunden";
            }
        }


        private string GenerateGermanIban(string bankIdent, string accountNumber)
        {
            IbanGenerator generator = new IbanGenerator();
            string iban = string.Empty;
            string bic = string.Empty;

            try
            {
                var result = generator.GenerateIban(ECountry.DE, bankIdent, accountNumber);
                iban = result.IBAN.IBAN;
                bic = result.BIC.Bic;
            }
            catch (IbanException ex)
            {
                this.Iban = "Nicht gefunden";
            }

            return iban;
        }

        private string GetGermanBank(string bankIdent, string accountNumber)
        {
            IbanGenerator generator = new IbanGenerator();
            Bank bank = null;

            try
            {
                var result = generator.GenerateIban(ECountry.DE, bankIdent, accountNumber);
                bank = result.IBAN.Bank;
            }
            catch (IbanException ex)
            {
                this.BankName = "Nicht gefunden";
            }

            return bank.Name;
        }

        private string GetGermanBic(string iban)
        {
            IbanGetBic getBic = new IbanGetBic();
            string bic = string.Empty;

            try
            {
                var result = getBic.GetBic(iban);
                bic = result.Bic;
            }
            catch (IbanException ex)
            {
                this.Bic = "Nicht gefunden";
            }

            return bic;
        }
    }
}