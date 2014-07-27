using AS.IBAN;
using AS.IBAN.Helper;
using AS.IBAN.Model;
using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.Pages.Student.Create;
using SailingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SailingSchoolWPF.ViewModel.InstructorViewModel
{
    /// <summary>
    /// ViewModel for instructor creation
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreateInstructorViewModel : ViewModel<SailingSchoolWPF.Model.Instructor>
    {

        #region Ctor
        public CreateInstructorViewModel(SailingSchoolWPF.Model.Instructor model)
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
                        instance = new CreateInstructorViewModel(new SailingSchoolWPF.Model.Instructor());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Properties
        private IList<SailingSchoolWPF.Model.Qualification> GetQualificationTypNames()
        {
            QualificationTypNames = new List<SailingSchoolWPF.Model.Qualification>();
            foreach (Model.Qualification quali in qualiMgr.GetAll())
            {
                QualificationTypNames.Add(quali);
            }
            return QualificationTypNames;
        }

        private IList<SailingSchoolWPF.Model.Qualification> QualificationTypNames;

        public IEnumerable<SailingSchoolWPF.Model.Qualification> QualificationValues
        {
            get
            {
                return GetQualificationTypNames();
            }
        }

        private SailingSchoolWPF.Model.Qualification _qualificationTyp;
        public SailingSchoolWPF.Model.Qualification QualificationTyp
        {
            get
            {
                return _qualificationTyp;
            }
            set
            {
                _qualificationTyp = value;
                this.OnPropertyChanged("QualificationTyp");
            }
        }

        private ObservableCollection<QualificationViewModel> qualifications;

        public ObservableCollection<QualificationViewModel> Qualifications
        {
            get
            {
                return qualifications;
            }
            set
            {
                if (Qualifications != value)
                {
                    qualifications = value;
                    this.OnPropertyChanged("Qualifications");
                }
            }
        }

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


        private string _huhu;
        public string Huhu
        {
            get
            {
                return "Dies ist eine Message";
            }
            set
            {
                _huhu = value;
                this.OnPropertyChanged("Huhu");
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

        private Decimal _honorarValueStd;
        public Decimal HonorarValueStd
        {
            get
            {
                return _honorarValueStd;
            }
            set
            {
                _honorarValueStd = value;
                this.OnPropertyChanged("HonorarValueStd");
            }
        }

        private Decimal _honorarValueDay;
        public Decimal HonorarValueDay
        {
            get
            {
                return _honorarValueDay;
            }
            set
            {
                _honorarValueDay = value;
                this.OnPropertyChanged("HonorarValueDay");
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

        private ObservableCollection<SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel> _blockedTimes;
        public ObservableCollection<SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel> BlockedTimes
        {
            get
            {
                return _blockedTimes;
            }
            set
            {
                if (_blockedTimes != value)
                {
                    _blockedTimes = value;
                    this.OnPropertyChanged("BlockedTimes");
                }
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate != DateTime.MinValue ? _startDate : DateTime.Now;
            }
            set
            {
                _startDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate != DateTime.MinValue ? _endDate : DateTime.Now;
            }
            set
            {
                _endDate = value;
                this.OnPropertyChanged("EndDate");
            }
        }

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

        private ICommand addTimeCommand;
        public ICommand AddTimeCommand
        {
            get
            {
                if (addTimeCommand == null)
                {
                    addTimeCommand = new RelayCommand(p => ExecuteAddTimeCommand());
                }
                return addTimeCommand;
            }
        }

        private void ExecuteAddTimeCommand()
        {
            SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel model = new Course.BlockedTimesViewModel(new BlockedTimeSpan());
            //    var dummyStart = this.StartDate;
            model.StartDate = this.StartDate.ToShortDateString();
            model.EndDate = this.EndDate.ToShortDateString();
            //  Model.InstructorId = this.Model.InstructorId;

            if (this.blockedDummyList == null)
            {
                this.blockedDummyList = new List<Course.BlockedTimesViewModel>();
            }
            this.blockedDummyList.Add(model);
            this.ReBindDataGrid();
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

        public void ExecuteDeleteCommand(QualificationViewModel quali)
        {
            this.dummy.Remove(quali);
            this.ReBindDataGrid();
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
            this.HonorarValueDay = 0;
            this.HonorarValueStd = 0;

            if (this.qualifications != null)
            {
                this.qualifications.Clear();
            }

            this.dummy.Clear();

            if (this.blockedDummyList != null)
            {
                this.blockedDummyList.Clear();
            }

            this.ReBindDataGrid();
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
            catch (Exception)
            {
                this.BankName = "Nicht gefunden";
                this.Iban = "Nicht gefunden";
                this.Bic = "Nicht gefunden";
            }
        }

        private ICommand addQualiCommand;
        public ICommand AddQualiCommand
        {
            get
            {
                if (addQualiCommand == null)
                {
                    addQualiCommand = new RelayCommand(p => ExecuteAddQualiCommand());
                }
                return addQualiCommand;
            }
        }

        private void ExecuteAddQualiCommand()
        {
            if (this.QualificationTyp == null)
                return;

            SailingSchoolWPF.Model.Qualification origQauli = this.QualificationTyp;
            QualificationViewModel quali = new QualificationViewModel(origQauli);
            if (this.qualifications == null)
            {
                this.qualifications = new ObservableCollection<QualificationViewModel>();
            }

            foreach (QualificationViewModel q in dummy)
            {
                if (q.ShortName == quali.ShortName)
                    return;
            }

            this.dummy.Add(quali);
            this.ReBindDataGrid();
        }

        public void ExecuteDeleteBlockCommand(SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel obj)
        {
            this.blockedDummyList.Remove(obj);
            this.ReBindDataGrid();
        }
        #endregion

        #region helpers
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
            catch (IbanException)
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
            catch (IbanException)
            {
                this.
                    BankName = "Nicht gefunden";
            }

            return bank.Name != null && bank.Name != string.Empty ? bank.Name : "Nicht gefunden";
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
            catch (IbanException)
            {
                this.Bic = "Nicht gefunden";
            }

            return bic;
        }

        private IList<SailingSchoolWPF.Model.Qualification> prepareQualifications(IList<QualificationViewModel> list)
        {
            IList<SailingSchoolWPF.Model.Qualification> qualiList = new List<SailingSchoolWPF.Model.Qualification>();

            foreach (QualificationViewModel q in list)
            {
                SailingSchoolWPF.Model.Qualification quali = new Model.Qualification();
                quali.QualificationId = q.Id;
                qualiList.Add(quali);
            }

            return qualiList;
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

            Model.FirstName = this.FirstName.Trim();
            Model.LastName = this.LastName.Trim();
            Model.Adress = adress;
            Model.Bank = bank;
            Model.Contact = contact;
            Model.Label = this.LastName.Trim() + ", " + this.FirstName.Trim();
            Model.FeeValueDay = this.HonorarValueDay;
            Model.FeeValueStd = this.HonorarValueStd;

            Model.AdditionalInfo = this.Notes;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            if (Model.Qualifications == null)
            {
                Model.Qualifications = new List<Model.Qualification>();
            }

            foreach (SailingSchoolWPF.Model.Qualification q in prepareQualifications(dummy))
            {
                Model.Qualifications.Add(q);
            }
            try
            {
                if (blockedDummyList != null)
                {
                    instructorMgr.Create(Model, blockedPreparedList(blockedDummyList));
                }
                else
                {
                    instructorMgr.Create(Model);
                }

            }
            catch (Exception ex)
            {
                // TODO ???
            }

        }
        private IList<BlockedTimeSpan> blockedPreparedList(IList<Course.BlockedTimesViewModel> blockedDummyList)
        {
            IList<BlockedTimeSpan> list = new List<BlockedTimeSpan>();
            foreach (Course.BlockedTimesViewModel b in blockedDummyList)
            {
                BlockedTimeSpan block = new BlockedTimeSpan();
                block.StartDate = DateTime.Parse(b.StartDate);
                block.EndDate = DateTime.Parse(b.EndDate);
                list.Add(block);
            }
            return list;
        }

        private void ReBindDataGrid()
        {
            if (this.qualifications != null)
            {
                this.qualifications.Clear();
            }

            if (this._blockedTimes != null)
            {
                this._blockedTimes.Clear();
            }

            if (blockedDummyList != null)
            {
                BlockedTimes = new ObservableCollection<SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel>(blockedDummyList);
            }

            Qualifications = new ObservableCollection<QualificationViewModel>(dummy);

        }

        private List<QualificationViewModel> dummy = new List<QualificationViewModel>();

        private ObservableCollection<Course.BlockedTimesViewModel> blockedDummy()
        {
            IList<BlockedTimeSpan> list = blockTimesMgr.GetAll();

            return prepareBlockTimes(list);

        }

        private ObservableCollection<Course.BlockedTimesViewModel> prepareBlockTimes(IList<BlockedTimeSpan> list)
        {
            ObservableCollection<SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel> blockList = new ObservableCollection<SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel>();

            foreach (SailingSchoolWPF.Model.BlockedTimeSpan b in list)
            {
                SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel blockView = new SailingSchoolWPF.ViewModel.Course.BlockedTimesViewModel(b);
                blockList.Add(blockView);
            }

            return blockList;
        }

        public IList<Course.BlockedTimesViewModel> blockedDummyList { get; set; }
        #endregion

        #region Methods

        public void Close()
        {
            instance = null;
        }
        #endregion



    }
}