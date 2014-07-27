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
using FirstFloor.ModernUI.Windows.Controls;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for course creation
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreateCourseViewModel : ViewModel<SailingSchoolWPF.Model.Course>
    {
        #region ctor
        public CreateCourseViewModel(SailingSchoolWPF.Model.Course model)
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
                        instance = new CreateCourseViewModel(new SailingSchoolWPF.Model.Course());
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

        public IEnumerable<SailingSchoolWPF.Model.Instructor> InstructorTypeValues
        {
            get
            {
                return GetInstructorNames();
            }
        }

        private IList<SailingSchoolWPF.Model.Instructor> GetInstructorNames()
        {
            InstructorNames = new List<SailingSchoolWPF.Model.Instructor>();
            foreach (Model.Instructor inst in instructorMgr.GetAll())
            {
                InstructorNames.Add(inst);
            }
            return InstructorNames;
        }

        private IList<SailingSchoolWPF.Model.Instructor> InstructorNames;

        private SailingSchoolWPF.Model.Instructor _instructor;
        public SailingSchoolWPF.Model.Instructor Instructor
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

        private IList<SailingSchoolWPF.Model.MaterialTyp> GetMaterialTypNames()
        {
            MaterialTypNames = new List<SailingSchoolWPF.Model.MaterialTyp>();
            foreach (Model.MaterialTyp matTyp in matTypMgr.GetAll())
            {
                MaterialTypNames.Add(matTyp);
            }
            return MaterialTypNames;
        }

        private IList<SailingSchoolWPF.Model.MaterialTyp> MaterialTypNames;

        public IEnumerable<SailingSchoolWPF.Model.MaterialTyp> MaterialTypValues
        {
            get
            {
                return GetMaterialTypNames();
            }
        }

        private ObservableCollection<CourseMaterialTypViewModel> _courseMaterialTyps;
        public ObservableCollection<CourseMaterialTypViewModel> CourseMaterialTyps
        {
            get
            {
                return _courseMaterialTyps;
            }
            set
            {
                _courseMaterialTyps = value;
                this.OnPropertyChanged("CourseMaterialTyps");
            }
        }

        private MaterialTyp _materialTyp;
        public MaterialTyp MaterialType
        {
            get
            {
                return _materialTyp;
            }
            set
            {
                _materialTyp = value;
                this.OnPropertyChanged("MaterialType");
            }
        }

        private int _matAmount;
        public int MatAmount
        {
            get
            {
                return _matAmount;
            }
            set
            {
                _matAmount = value;
                this.OnPropertyChanged("MatAmount");
            }
        }

        private IList<SailingSchoolWPF.Model.BoatTyp> GetBoatTypNames()
        {
            BoatTypNames = new List<SailingSchoolWPF.Model.BoatTyp>();
            foreach (Model.BoatTyp boatTyp in boatTypMgr.GetAll())
            {
                BoatTypNames.Add(boatTyp);
            }
            return BoatTypNames;
        }

        private IList<SailingSchoolWPF.Model.BoatTyp> BoatTypNames;

        public IEnumerable<SailingSchoolWPF.Model.BoatTyp> BoatTypValues
        {
            get
            {
                return GetBoatTypNames();
            }
        }

        private SailingSchoolWPF.Model.BoatTyp _boatTyp;
        public SailingSchoolWPF.Model.BoatTyp BoatTyp
        {
            get
            {
                return _boatTyp;
            }
            set
            {
                _boatTyp = value;
                this.OnPropertyChanged("BoatTyp");
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
            this.BoatTyp = null;

            if (this.qualifications != null)
            {
                this.qualifications.Clear();
            }

            this.MaterialType = null;
            if (this._courseMaterialTyps != null)
            {
                this._courseMaterialTyps.Clear();
            }

            this.dummy.Clear();
            this.ReBindDataGrid();
        }

        public void ExecuteDeleteCommand(QualificationViewModel quali)
        {
            this.dummy.Remove(quali);
            this.ReBindDataGrid();
        }

        public void ExecuteMatDeleteCommand(CourseMaterialTypViewModel couseMatTyp)
        {
            this.matTypDummy.Remove(couseMatTyp);
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

        private ICommand addMatTypCommand;
        public ICommand AddMatTypCommand
        {
            get
            {
                if (addMatTypCommand == null)
                {
                    addMatTypCommand = new RelayCommand(p => ExecuteAddMatTypCommand());
                }
                return addMatTypCommand;
            }
        }

        private void ExecuteAddMatTypCommand()
        {
            CourseMaterialTypViewModel model = new CourseMaterialTypViewModel(new CourseMaterialTyp());

            model.MaterialTyp = this.MaterialType;
            model.MatAmount = this.MatAmount;


            if (this.matTypDummy == null)
            {
                this.matTypDummy = new List<CourseMaterialTypViewModel>();
            }

            foreach (CourseMaterialTypViewModel m in matTypDummy)
            {
                if (m.Name == model.Name)
                    return;
            }
            this.matTypDummy.Add(model);
            this.ReBindDataGrid();

        }
        #endregion

        #region helpers
        public void Close()
        {
            instance = null;
        }


        private List<QualificationViewModel> dummy = new List<QualificationViewModel>();

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

        private List<CourseMaterialTypViewModel> matTypDummy = new List<CourseMaterialTypViewModel>();

        private IList<SailingSchoolWPF.Model.CourseMaterialTyp> prepareMaterialTyps(IList<CourseMaterialTypViewModel> list)
        {
            IList<SailingSchoolWPF.Model.CourseMaterialTyp> matTypList = new List<SailingSchoolWPF.Model.CourseMaterialTyp>();

            foreach (CourseMaterialTypViewModel m in list)
            {
                SailingSchoolWPF.Model.CourseMaterialTyp matTyp = new Model.CourseMaterialTyp();
                matTyp.Id = m.Id;
                matTyp.MaterialTyp = m.MaterialTyp;
                matTyp.Amount = m.MatAmount;
                matTypList.Add(matTyp);
            }

            return matTypList;
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
            Model.BoatTyp = this.BoatTyp;

            if (Model.Qualifications == null)
            {
                Model.Qualifications = new List<Model.Qualification>();
            }

            foreach (SailingSchoolWPF.Model.Qualification q in prepareQualifications(dummy))
            {
                Model.Qualifications.Add(q);
            }

            if (Model.CourseMaterialTyps == null)
            {
                Model.CourseMaterialTyps = new List<Model.CourseMaterialTyp>();
            }

            foreach (SailingSchoolWPF.Model.CourseMaterialTyp m in prepareMaterialTyps(matTypDummy))
            {
                Model.CourseMaterialTyps.Add(m);
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

            if (this._courseMaterialTyps != null)
            {
                this._courseMaterialTyps.Clear();
            }

            CourseMaterialTyps = new ObservableCollection<CourseMaterialTypViewModel>(matTypDummy);
        }

        #endregion
    }
}