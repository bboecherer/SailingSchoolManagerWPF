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

namespace SealingSchoolWPF.ViewModel.StudentViewModel
{
    public class UpdateStudentViewModel : ViewModel<Student>
    {
        public Student StudentDummy { get; set; }

        public UpdateStudentViewModel(Student model)
            : base(model)
        {
            instance = this;
            this.StudentDummy = model;
        }

        static UpdateStudentViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateStudentViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateStudentViewModel(new SealingSchoolWPF.Model.Student());
                    }
                    return instance;
                }
            }
        }

        StudentMgr studMgr = new StudentMgr();

        public string FirstName
        {
            get
            {
                return StudentDummy.FirstName;
            }
            set
            {
                StudentDummy.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return StudentDummy.LastName;
            }
            set
            {
                StudentDummy.LastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public string Street
        {
            get
            {
                return StudentDummy.Adress.Street;
            }
            set
            {
                StudentDummy.Adress.Street = value;
                this.OnPropertyChanged("Street");
            }
        }

        public string Postal
        {
            get
            {
                return StudentDummy.Adress.ZipCode;
            }
            set
            {
                StudentDummy.Adress.ZipCode = value;
                this.OnPropertyChanged("Postal");
            }
        }

        public string City
        {
            get
            {
                return StudentDummy.Adress.City;
            }
            set
            {
                StudentDummy.Adress.City = value;
                this.OnPropertyChanged("City");
            }
        }

        public string AccountNo
        {
            get
            {
                return StudentDummy.Bank.AccountNo;
            }
            set
            {
                StudentDummy.Bank.AccountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        public string BankNo
        {
            get
            {
                return StudentDummy.Bank.BankNo;
            }
            set
            {
                StudentDummy.Bank.BankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        public string BankName
        {
            get
            {
                return StudentDummy.Bank.BankName;
            }
            set
            {
                StudentDummy.Bank.BankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        public string Iban
        {
            get
            {
                return StudentDummy.Bank.Iban;
            }
            set
            {
                StudentDummy.Bank.Iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        public bool Sepa
        {
            get
            {
                return StudentDummy.Bank.Sepa;
            }
            set
            {
                StudentDummy.Bank.Sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        public string Bic
        {
            get
            {
                return StudentDummy.Bank.Bic;
            }
            set
            {
                StudentDummy.Bank.Bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        public string Notes
        {
            get
            {
                return StudentDummy.AdditionalInfo;
            }
            set
            {
                StudentDummy.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
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
            studMgr.Update(Model);
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