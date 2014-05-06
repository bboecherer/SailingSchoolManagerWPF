﻿using AS.IBAN;
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
    public class CreateInstructorViewModel : ViewModel<SealingSchoolWPF.Model.Instructor>
    {

        #region Ctor
        public CreateInstructorViewModel(SealingSchoolWPF.Model.Instructor model)
            : base(model)
        {
        }

        static CreateInstructorViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateInstructorViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateInstructorViewModel(new SealingSchoolWPF.Model.Instructor());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Properties

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

        private bool _SSS;
        public bool SSS
        {
            get
            {
                return _SSS;
            }
            set
            {
                _SSS = value;
                this.OnPropertyChanged("SSS");
            }
        }

        private bool _SKS;
        public bool SKS
        {
            get
            {
                return _SKS;
            }
            set
            {
                _SKS = value;
                this.OnPropertyChanged("SKS");
            }
        }

        private bool _SBFSEA;
        public bool SBFSEA
        {
            get
            {
                return _SBFSEA;
            }
            set
            {
                _SBFSEA = value;
                this.OnPropertyChanged("SBFSEA");
            }
        }

        private bool _SBFBINNEN;
        public bool SBFBINNEN
        {
            get
            {
                return _SBFBINNEN;
            }
            set
            {
                _SBFBINNEN = value;
                this.OnPropertyChanged("SBFBINNEN");
            }
        }

        private bool _SRC;
        public bool SRC
        {
            get
            {
                return _SRC;
            }
            set
            {
                _SRC = value;
                this.OnPropertyChanged("SRC");
            }
        }

        private bool _UBI;
        public bool UBI
        {
            get
            {
                return _UBI;
            }
            set
            {
                _UBI = value;
                this.OnPropertyChanged("UBI");
            }
        }

        private bool _DSV;
        public bool DSV
        {
            get
            {
                return _DSV;
            }
            set
            {
                _DSV = value;
                this.OnPropertyChanged("DSV");
            }
        }

        private bool _SHS;
        public bool SHS
        {
            get
            {
                return _SHS;
            }
            set
            {
                _SHS = value;
                this.OnPropertyChanged("SHS");
            }
        }

        private bool _lifeGuard;
        public bool LifeGuard
        {
            get
            {
                return _lifeGuard;
            }
            set
            {
                _lifeGuard = value;
                this.OnPropertyChanged("LifeGuard");
            }
        }

        private DateTime _SSSDate;
        public DateTime SSSDate
        {
            get
            {
                if (_SSSDate == null || _SSSDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _SSSDate;
                }
            }
            set
            {
                _SSSDate = value;
                this.OnPropertyChanged("SSSDate");
            }
        }

        private DateTime _SKSDate;
        public DateTime SKSDate
        {
            get
            {
                if (_SKSDate == null || _SKSDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _SKSDate;
                }
            }
            set
            {
                _SKSDate = value;
                this.OnPropertyChanged("SKSDate");
            }
        }

        private DateTime _SBFSEADate;
        public DateTime SBFSEADate
        {
            get
            {
                if (_SBFSEADate == null || _SBFSEADate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _SBFSEADate;
                }
            }
            set
            {
                _SBFSEADate = value;
                this.OnPropertyChanged("SBFSEADate");
            }
        }

        private DateTime _SBFBINNENDate;
        public DateTime SBFBINNENDate
        {
            get
            {
                if (_SBFBINNENDate == null || _SBFBINNENDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _SBFBINNENDate;
                }
            }
            set
            {
                _SBFBINNENDate = value;
                this.OnPropertyChanged("SBFBINNENDate");
            }
        }

        private DateTime _SRCDate;
        public DateTime SRCDate
        {
            get
            {
                if (_SRCDate == null || _SRCDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _SRCDate;
                }
            }
            set
            {
                _SRCDate = value;
                this.OnPropertyChanged("SRCDate");
            }
        }

        private DateTime _UBIDate;
        public DateTime UBIDate
        {
            get
            {
                if (_UBIDate == null || _UBIDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _UBIDate;
                }
            }
            set
            {
                _UBIDate = value;
                this.OnPropertyChanged("UBIDate");
            }
        }

        private DateTime _DSVDate;
        public DateTime DSVDate
        {
            get
            {
                if (_DSVDate == null || _DSVDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _DSVDate;
                }
            }
            set
            {
                _DSVDate = value;
                this.OnPropertyChanged("DSVDate");
            }
        }

        private DateTime _SHSDate;
        public DateTime SHSDate
        {
            get
            {
                if (_SHSDate == null || _SHSDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _SHSDate;
                }
            }
            set
            {
                _SHSDate = value;
                this.OnPropertyChanged("SHSDate");
            }
        }

        private DateTime _lifeGuardDate;
        public DateTime LifeGuardDate
        {
            get
            {
                if (_lifeGuardDate == null || _lifeGuardDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _lifeGuardDate;
                }
            }
            set
            {
                _lifeGuardDate = value;
                this.OnPropertyChanged("LifeGuardDate");
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

        private string _imageSourceClear = "/Resources/Images/action_Cancel_16xLG.png";
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

        #endregion

        #region Members
        private InstructorMgr instructorMgr = new InstructorMgr();
        #endregion

        #region Commands

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

            adress.Street = this.Street;
            adress.ZipCode = this.Postal;
            adress.City = this.City;
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

            Model.SSS = this.SSS;
            Model.SSSDate = this.SSSDate;
            Model.SKS = this.SKS;
            Model.SKSDate = this.SKSDate;
            Model.SBFSEA = this.SBFSEA;
            Model.SBFSEADate = this.SBFSEADate;
            Model.SBFBINNEN = this.SBFBINNEN;
            Model.SBFBINNENDate = this.SBFBINNENDate;
            Model.SRC = this.SRC;
            Model.SRCDate = this.SRCDate;
            Model.UBI = this.UBI;
            Model.UBIDate = this.UBIDate;
            Model.DSV = this.DSV;
            Model.DSVDate = this.DSVDate;
            Model.SHS = this.SHS;
            Model.SHSDate = this.SHSDate;
            Model.LifeGuard = this.LifeGuard;
            Model.LifeGuardDate = this.LifeGuardDate;

            Model.AdditionalInfo = this.Notes;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            instructorMgr.Create(Model);

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


            this.IsButtonEnabled = false;
            this.ImageSourceSave = "/Resources/Images/StatusAnnotations_Complete_and_ok_32xLG_color.png";
            this.ImageSourceClear = "";
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
            this.BankName = GetGermanBank(this.BankNo, this.AccountNo);
            this.Iban = GenerateGermanIban(this.BankNo, this.AccountNo);
            this.Bic = GetGermanBic(this.Iban);
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
                //  do some error handling
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
                //  do some error handling
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
                //  do some error handling
            }

            return bic;
        }


        #endregion

        #region Methods

        public void Close()
        {
            instance = null;
        }
        #endregion
    }
}