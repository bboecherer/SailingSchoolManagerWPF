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
            Adress adress = new Adress();
            BankAccountData bank = new BankAccountData();
            ContactData contact = new ContactData();
            contact.Email = "dummy";

            adress.AddressLine1 = this.Street;
            adress.ZipCode = this.Postal;
            adress.City = this.City;

            bank.AccountNo = this.AccountNo;
            bank.BankName = this.BankName;
            bank.BankNo = this.BankNo;
            bank.Bic = this.Bic;
            bank.Iban = this.Iban;

            Model.FirstName = this.FirstName;
            Model.LastName = this.LastName;
            Model.Adress = adress;
            Model.Bank = bank;
            Model.Contact = contact;

            Model.AdditionalInfo = this.Notes;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            instructorMgr.Create(Model);

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

        #endregion

        #region Methods

        public void Close()
        {
            instance = null;

        }
        #endregion
    }
}