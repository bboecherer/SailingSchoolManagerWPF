using AS.IBAN;
using AS.IBAN.Helper;
using AS.IBAN.Model;
using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.BusinessUnit;
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

        #region ctor
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
        #endregion

        #region properties
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

        private Double _ratingValue;
        public Double RatingValue
        {
            get
            {
                return _ratingValue != 0 ? _ratingValue : Model.RatingValue;
            }
            set
            {
                _ratingValue = value;
                this.OnPropertyChanged("RatingValue");
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

        private DateTime _startDatePicker;
        public DateTime StartDatePicker
        {
            get
            {
                return _startDatePicker != DateTime.MinValue ? _startDatePicker : DateTime.Now;
            }
            set
            {
                _startDatePicker = value;
                this.OnPropertyChanged("StartDatePicker");
            }
        }

        private DateTime _endDatePicker;
        public DateTime EndDatePicker
        {
            get
            {
                return _endDatePicker != DateTime.MinValue ? _endDatePicker : DateTime.Now;
            }
            set
            {
                _endDatePicker = value;
                this.OnPropertyChanged("EndDatePicker");
            }
        }

        public Decimal HonorarValueStd
        {
            get
            {
                return InstructorDummy.FeeValueStd;
            }
            set
            {
                InstructorDummy.FeeValueStd = value;
                this.OnPropertyChanged("HonorarValueStd");
            }
        }

        public Decimal HonorarValueDay
        {
            get
            {
                return InstructorDummy.FeeValueDay;
            }
            set
            {
                InstructorDummy.FeeValueDay = value;
                this.OnPropertyChanged("HonorarValueDay");
            }
        }

        private string _saveImage = "/Resources/Images/save_16xLG.png";
        public string SaveImage
        {
            get
            {
                return _saveImage;
            }
            set
            {
                _saveImage = value;
                this.OnPropertyChanged("SaveImage");
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

        private IList<SealingSchoolWPF.Model.Qualification> GetQualificationTypNames()
        {
            QualificationTypNames = new List<SealingSchoolWPF.Model.Qualification>();
            foreach (Model.Qualification quali in qualiMgr.GetAll())
            {
                QualificationTypNames.Add(quali);
            }
            return QualificationTypNames;
        }

        private IList<SealingSchoolWPF.Model.Qualification> QualificationTypNames;

        public IEnumerable<SealingSchoolWPF.Model.Qualification> QualificationValues
        {
            get
            {
                return GetQualificationTypNames();
            }
        }

        private SealingSchoolWPF.Model.Qualification _qualificationTyp;
        public SealingSchoolWPF.Model.Qualification QualificationTyp
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
                return qualiList();
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

        private ObservableCollection<CoursePlaning> references;
        public ObservableCollection<CoursePlaning> References
        {
            get
            {
                return referenceList();
            }
            set
            {
                if (References != value)
                {
                    references = value;
                    this.OnPropertyChanged("References");
                }
            }
        }

        private ObservableCollection<SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel> _blockedTimes;
        public ObservableCollection<SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel> BlockedTimes
        {
            get
            {
                return this.blockedDummy();
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
        #endregion

        #region commands
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
            Model.ModifiedOn = DateTime.Now;

            Model.Qualifications.Clear();

            if (prepared != null)
            {
                foreach (QualificationViewModel q in prepared)
                {
                    Model.Qualifications.Add(prepareQualiToSave(q));
                }
            }

            Model.RatingValue = this._ratingValue;

            instructorMgr.Update(Model);

            if (this.list != null && this.list.Count > 0)
            {
                blockTimesMgr.Update(this.list);
            }

            this.SaveImage = "/Resources/Images/StatusAnnotations_Complete_and_ok_16xLG_color.png";
            this.IsButtonEnabled = false;
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

        public void ExecuteDeleteCommand(QualificationViewModel quali)
        {
            this.prepared.Remove(quali);
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
            if (this.list == null)
            {
                this.list = new List<BlockedTimeSpan>();
            }

            SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel model = new Course.BlockedTimesViewModel(new BlockedTimeSpan());
            model.StartDate = this.StartDatePicker.ToShortDateString();
            model.EndDate = this.EndDatePicker.ToShortDateString();

            //prüfen, ob es Terminüberschneidungen gibt
            // this.blockTimesMgr.checkTimes( prepareBlockTimesToModel( model ) );

            this.list.Add(prepareBlockTimesToModel(model));
            this.ReBindDataGrid();
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

            SealingSchoolWPF.Model.Qualification origQauli = this.QualificationTyp;
            QualificationViewModel quali = new QualificationViewModel(origQauli);

            foreach (QualificationViewModel q in prepared)
            {
                if (q.ShortName == quali.ShortName)
                    return;
            }

            this.prepared.Add(quali);
        }

        public void ExecuteDeleteBlockCommand(SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel obj)
        {
            if (this.blockedDummyList != null)
            {
                this.blockedDummyList.Remove(obj);
                BlockedTimeSpan dummy = this.prepareBlockTimesToModel(obj);
                this.list.Remove(dummy);
            }
            ReBindDataGrid();

        }
        #endregion

        #region helpers
        public IList<Course.BlockedTimesViewModel> blockedDummyList { get; set; }

        private void ReBindDataGrid()
        {
            if (blockedDummyList != null)
            {
                BlockedTimes = new ObservableCollection<SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel>(blockedDummyList);
            }
        }

        public void Close()
        {
            instance = null;

        }

        private SealingSchoolWPF.Model.Qualification prepareQualiToSave(QualificationViewModel q)
        {
            SealingSchoolWPF.Model.Qualification quali = new Model.Qualification();
            quali.QualificationId = q.Id;
            return quali;
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
                this.BankName = "Nicht gefunden";
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


        private ObservableCollection<QualificationViewModel> prepared;

        private ObservableCollection<QualificationViewModel> qualiList()
        {
            if (prepared == null || prepared.Count == 0)
            {
                prepared = new ObservableCollection<QualificationViewModel>();
            }
            foreach (QualificationViewModel q in prepareQualifications(Model.Qualifications))
            {
                prepared.Add(q);
            }
            return prepared;
        }

        private ObservableCollection<CoursePlaning> preparedReferences;

        private ObservableCollection<CoursePlaning> referenceList()
        {
            if (preparedReferences == null || preparedReferences.Count == 0)
            {
                preparedReferences = new ObservableCollection<CoursePlaning>();
            }
            foreach (CoursePlaning q in coursePlaningMgr.GetInstructorReference(Model.InstructorId))
            {
                preparedReferences.Add(q);
            }
            return preparedReferences;
        }


        private ObservableCollection<QualificationViewModel> prepareQualifications(ICollection<SealingSchoolWPF.Model.Qualification> collection)
        {
            ObservableCollection<QualificationViewModel> list = new ObservableCollection<QualificationViewModel>();

            foreach (Model.Qualification q in collection)
            {
                QualificationViewModel model = new QualificationViewModel(q);
                list.Add(model);
            }

            return list;
        }

        private IList<BlockedTimeSpan> list;

        private ObservableCollection<Course.BlockedTimesViewModel> blockedDummy()
        {
            if (this.list == null)
            {
                list = blockTimesMgr.GetByInstructor(this.InstructorDummy.InstructorId);
            }
            this.blockedDummyList = prepareBlockTimes(list);
            return list != null ? prepareBlockTimes(list) : null;

        }

        private ObservableCollection<Course.BlockedTimesViewModel> prepareBlockTimes(IList<BlockedTimeSpan> list)
        {
            ObservableCollection<SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel> blockList = new ObservableCollection<SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel>();

            foreach (SealingSchoolWPF.Model.BlockedTimeSpan b in list)
            {
                SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel blockView = new SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel(b);
                blockList.Add(blockView);
            }

            return blockList;
        }

        private BlockedTimeSpan prepareBlockTimesToModel(Course.BlockedTimesViewModel model)
        {
            BlockedTimeSpan block = new BlockedTimeSpan();
            block.BlockedTimeSpanId = model.Id;
            block.Course = model.Course;
            block.EndDate = DateTime.Parse(model.EndDate);
            block.StartDate = DateTime.Parse(model.StartDate);
            block.Instructor = Model;

            return block;
        }


        #endregion

    }
}