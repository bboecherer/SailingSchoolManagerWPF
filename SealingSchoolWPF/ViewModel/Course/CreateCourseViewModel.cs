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

namespace SealingSchoolWPF.ViewModel.Course
{
    public class CreateCourseViewModel : ViewModel<SealingSchoolWPF.Model.Course>
    {
        #region ctor
        public CreateCourseViewModel(SealingSchoolWPF.Model.Course model)
            : base(model)
        {
        }

        static CreateCourseViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateCourseViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateCourseViewModel(new SealingSchoolWPF.Model.Course());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                this.OnPropertyChanged("Label");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                this.OnPropertyChanged("Description");
            }
        }

        private int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                this.OnPropertyChanged("Duration");
            }
        }

        private int _capacity;
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
                this.OnPropertyChanged("Capacity");
            }
        }

        public IEnumerable<SealingSchoolWPF.Model.Instructor> InstructorTypeValues
        {
            get
            {
                return GetInstructorNames();
            }
        }

        private IList<SealingSchoolWPF.Model.Instructor> GetInstructorNames()
        {
            InstructorNames = new List<SealingSchoolWPF.Model.Instructor>();
            foreach (Model.Instructor inst in instructorMgr.GetAll())
            {
                InstructorNames.Add(inst);
            }
            return InstructorNames;
        }

        private IList<SealingSchoolWPF.Model.Instructor> InstructorNames;

        private SealingSchoolWPF.Model.Instructor _instructor;
        public SealingSchoolWPF.Model.Instructor Instructor
        {
            get
            {
                return _instructor;
            }
            set
            {
                _instructor = value;
                this.OnPropertyChanged("Instructor");
            }
        }

        private Decimal _netPrice;
        public Decimal NetPrice
        {
            get
            {
                return _netPrice;
            }
            set
            {
                _netPrice = value;
                this.OnPropertyChanged("NetPrice");
            }
        }

        private Decimal _grossPrice;
        public Decimal GrossPrice
        {
            get
            {
                return _grossPrice;
            }
            set
            {
                _grossPrice = value;
                this.CalculatePrice(value);
                this.OnPropertyChanged("GrossPrice");
            }
        }

        private Decimal _netAmount;
        public Decimal NetAmount
        {
            get
            {
                return _netAmount;
            }
            set
            {
                _netAmount = value;
                this.OnPropertyChanged("NetAmount");
            }
        }


        public IEnumerable<Currency> CurrencyTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(Currency))
                    .Cast<Currency>();
            }
        }

        private Currency _currency;
        public Currency Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                this.OnPropertyChanged("Currency");
            }
        }

        private int _neededInstructors;
        public int NeededInstructors
        {
            get
            {
                return _neededInstructors;
            }
            set
            {
                _neededInstructors = value;
                this.OnPropertyChanged("NeededInstructors");
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
            this.Label = null;
            this.NetAmount = 0;
            this.NetPrice = 0;
            this.Notes = null;
            this.Duration = 0;
            this.Capacity = 0;
            this.Description = null;
            this.GrossPrice = 0;
            this.Instructor = null;
            this.Notes = null;
            this.NeededInstructors = 0;

            if (this.qualifications != null)
            {
                this.qualifications.Clear();
            }

            this.dummy.Clear();
            this.ReBindDataGrid();
        }

        public void ExecuteDeleteCommand(QualificationViewModel quali)
        {
            this.dummy.Remove(quali);
            this.ReBindDataGrid();
        }

        private void ExecuteAddCommand()
        {
            SaveModelToDatabase();
            Application.Current.Windows[1].Close();
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
        #endregion

        #region helpers
        public void Close()
        {
            instance = null;
        }


        private List<QualificationViewModel> dummy = new List<QualificationViewModel>();

        private IList<SealingSchoolWPF.Model.Qualification> prepareQualifications(IList<QualificationViewModel> list)
        {
            IList<SealingSchoolWPF.Model.Qualification> qualiList = new List<SealingSchoolWPF.Model.Qualification>();

            foreach (QualificationViewModel q in list)
            {
                SealingSchoolWPF.Model.Qualification quali = new Model.Qualification();
                quali.QualificationId = q.Id;
                qualiList.Add(quali);
            }

            return qualiList;
        }

        private void SaveModelToDatabase()
        {
            Model.Label = this.Label;
            Model.Description = this.Description;
            Model.Duration = this.Duration;
            Model.Capacity = this.Capacity;
            Model.AdditionalInfo = this.Notes;
            Model.NetPrice = this.NetPrice;
            Model.GrossPrice = this.GrossPrice;
            Model.NetAmount = this.NetAmount;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
            Model.NeededInstructors = this.NeededInstructors;

            if (Model.Qualifications == null)
            {
                Model.Qualifications = new List<Model.Qualification>();
            }

            foreach (SealingSchoolWPF.Model.Qualification q in prepareQualifications(dummy))
            {
                Model.Qualifications.Add(q);
            }

            courseMgr.Create(Model);
        }

        private void CalculatePrice(decimal p)
        {
            decimal grossPrice = p;
            decimal netPrice = decimal.MinValue;
            decimal vat = 19;

            netPrice = grossPrice / ((100 + vat) / 100);
            this.NetAmount = (netPrice * vat / 100);
            this.NetPrice = netPrice;
        }

        private void ReBindDataGrid()
        {
            if (this.qualifications != null)
            {
                this.qualifications.Clear();
            }

            Qualifications = new ObservableCollection<QualificationViewModel>(dummy);
        }
        #endregion
    }
}