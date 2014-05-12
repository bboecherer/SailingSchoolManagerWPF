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
    public class CreateStudentViewModel : ViewModel<Student>
    {

        public CreateStudentViewModel(Student model)
            : base(model)
        {
        }

        static CreateStudentViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateStudentViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateStudentViewModel(new SealingSchoolWPF.Model.Student());
                    }
                    return instance;
                }
            }
        }

        StudentMgr studMgr = new StudentMgr();

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                this.OnPropertyChanged("Street");
            }
        }

        private string _postal;
        public string Postal
        {
            get
            {
                return _postal;
            }
            set
            {
                _postal = value;
                this.OnPropertyChanged("Postal");
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                this.OnPropertyChanged("City");
            }
        }

        private string _accountNo;
        public string AccountNo
        {
            get
            {
                return _accountNo;
            }
            set
            {
                _accountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        private string _bankNo;
        public string BankNo
        {
            get
            {
                return _bankNo;
            }
            set
            {
                _bankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        private string _bankName;
        public string BankName
        {
            get
            {
                return _bankName;
            }
            set
            {
                _bankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        private string _iban;
        public string Iban
        {
            get
            {
                return _iban;
            }
            set
            {
                _iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        private bool _sepa;
        public bool Sepa
        {
            get
            {
                return _sepa;
            }
            set
            {
                _sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        private string _bic;
        public string Bic
        {
            get
            {
                return _bic;
            }
            set
            {
                _bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                this.OnPropertyChanged("Notes");
            }
        }

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get
            {
                return _isButtonEnabled;
            }
            set
            {
                _isButtonEnabled = value;
                this.OnPropertyChanged("IsButtonEnabled");
            }
        }

        private string _imageSourceSave = "/Resources/Images/save_16xLG.png";
        public string ImageSourceSave
        {
            get
            {
                return _imageSourceSave;
            }
            set
            {
                _imageSourceSave = value;
                this.OnPropertyChanged("ImageSourceSave");
            }
        }

        private string _imageSourceNext = "/Resources/Images/arrow_Next_16xLG.png";
        public string ImageSourceNext
        {
            get
            {
                return _imageSourceNext;
            }
            set
            {
                _imageSourceNext = value;
                this.OnPropertyChanged("ImageSourceNext");
            }
        }

        private string _imageSourceClear = "/Resources/Images/Undo_16x.png";
        public string ImageSourceClear
        {
            get
            {
                return _imageSourceClear;
            }
            set
            {
                _imageSourceClear = value;
                this.OnPropertyChanged("ImageSourceClear");
            }
        }

        private ICommand addAndNextCommand;

        public ICommand AddAndNextCommand
        {
            get
            {
                if (addAndNextCommand == null)
                {
                    addAndNextCommand = new RelayCommand(p => ExecuteAddAndNextCommand());
                }
                return addAndNextCommand;
            }
        }

        private void ExecuteAddAndNextCommand()
        {
            SaveModelToDatabase();
            this.ExecuteClearCommand();
            this.Close();
        }

        private void SaveModelToDatabase()
        {
            Adress adress = new Adress();
            BankAccountData bank = new BankAccountData();
            ContactData contact = new ContactData();
            contact.Email = "dummy";

            adress.ZipCode = this.Postal;
            adress.City = this.City;
            adress.Street = this.Street;
            adress.AddressLine1 = this.Street + ", " + this.Postal + " " + this.City;

            bank.AccountNo = this.AccountNo;
            bank.BankName = this.BankName;
            bank.BankNo = this.BankNo;
            bank.Bic = this.Bic;
            bank.Iban = this.Iban;
            bank.Sepa = this.Sepa;

            Model.FirstName = this.FirstName;
            Model.LastName = this.LastName;
            Model.Adress = adress;
            Model.Bank = bank;
            Model.Contact = contact;
            Model.Label = this.FirstName + " " + this.LastName;

            Model.AdditionalInfo = this.Notes;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            studMgr.Create(Model);
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



        private void ExecuteAddCommand()
        {
            SaveModelToDatabase();

            // this.IsButtonEnabled = false;
            // this.ImageSourceSave = "/Resources/Images/StatusAnnotations_Complete_and_ok_32xLG_color.png";
            // this.ImageSourceClear = "";
            Application.Current.Windows[1].Close();
        }

        private ICommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(p => ExecuteClearCommand());
                }
                return clearCommand;
            }
        }

        private void ExecuteClearCommand()
        {
            this.FirstName = null;
            this.LastName = null;
            this.Postal = null;
            this.City = null;
            this.Street = null;
            this.AccountNo = null;
            this.BankName = null;
            this.BankNo = null;
            this.Bic = null;
            this.Iban = null;
            this.Notes = null;
            this.Sepa = false;
        }

        public void Close()
        {
            instance = null;
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