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
    public class UpdateCourseViewModel : ViewModel<Model.Course>
    {
        public Model.Course CourseDummy { get; set; }

        #region ctor
        public UpdateCourseViewModel(Model.Course model)
            : base(model)
        {
            instance = this;
            this.CourseDummy = model;
        }

        static UpdateCourseViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateCourseViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateCourseViewModel(new SealingSchoolWPF.Model.Course());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        public string Label
        {
            get
            {
                return CourseDummy.Label;
            }
            set
            {
                CourseDummy.Label = value;
                this.OnPropertyChanged("Label");
            }
        }

        private Double _ratingValue;
        public Double RatingValue
        {
            get
            {
                return _ratingValue != null && _ratingValue != 0 ? _ratingValue : Model.RatingValue;
            }
            set
            {
                _ratingValue = value;
                this.OnPropertyChanged("RatingValue");
            }
        }

        public int Duration
        {
            get
            {
                return CourseDummy.Duration;
            }
            set
            {
                CourseDummy.Duration = value;
                this.OnPropertyChanged("Duration");
            }
        }

        public int Capacity
        {
            get
            {
                return CourseDummy.Capacity;
            }
            set
            {
                CourseDummy.Capacity = value;
                this.OnPropertyChanged("Capacity");
            }
        }

        public Decimal NetPrice
        {
            get
            {
                return CourseDummy.NetPrice;
            }
            set
            {
                CourseDummy.NetPrice = value;
                this.OnPropertyChanged("NetPrice");
            }
        }

        public Decimal GrossPrice
        {
            get
            {
                return CourseDummy.GrossPrice;
            }
            set
            {
                CourseDummy.GrossPrice = value;
                this.CalculatePrice(value);
                this.OnPropertyChanged("GrossPrice");
            }
        }

        public Decimal NetAmount
        {
            get
            {
                return CourseDummy.NetAmount;
            }
            set
            {
                CourseDummy.NetAmount = value;
                this.OnPropertyChanged("NetAmount");
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

        public string Notes
        {
            get
            {
                return CourseDummy.AdditionalInfo;
            }
            set
            {
                CourseDummy.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
            }
        }

        public string Description
        {
            get
            {
                return CourseDummy.Description;
            }
            set
            {
                CourseDummy.Description = value;
                this.OnPropertyChanged("Description");
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

        public Currency Currency
        {
            get
            {
                return CourseDummy.Currency;
            }
            set
            {
                CourseDummy.Currency = value;
                this.OnPropertyChanged("Currency");
            }
        }

        public int NeededInstructors
        {
            get
            {
                return CourseDummy.NeededInstructors;
            }
            set
            {
                CourseDummy.NeededInstructors = value;
                this.OnPropertyChanged("NeededInstructors");
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

        private IList<SealingSchoolWPF.Model.MaterialTyp> GetMaterialTypNames()
        {
            MaterialTypNames = new List<SealingSchoolWPF.Model.MaterialTyp>();
            foreach (Model.MaterialTyp matTyp in matTypMgr.GetAll())
            {
                MaterialTypNames.Add(matTyp);
            }
            return MaterialTypNames;
        }

        private IList<SealingSchoolWPF.Model.MaterialTyp> MaterialTypNames;

        public IEnumerable<SealingSchoolWPF.Model.MaterialTyp> MaterialTypValues
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
                return matTypList();
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

        private IList<SealingSchoolWPF.Model.BoatTyp> GetBoatTypNames()
        {
            BoatTypNames = new List<SealingSchoolWPF.Model.BoatTyp>();
            foreach (Model.BoatTyp boatTyp in boatTypMgr.GetAll())
            {
                BoatTypNames.Add(boatTyp);
            }
            return BoatTypNames;
        }

        private IList<SealingSchoolWPF.Model.BoatTyp> BoatTypNames;

        public IEnumerable<SealingSchoolWPF.Model.BoatTyp> BoatTypValues
        {
            get
            {
                return GetBoatTypNames();
            }
        }


        public SealingSchoolWPF.Model.BoatTyp BoatTyp
        {
            get
            {
                return CourseDummy.BoatTyp;
            }
            set
            {
                CourseDummy.BoatTyp = value;
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

            if (preparedMat != null)
            {
                foreach (CourseMaterialTyp m in prepareMaterialTyps(preparedMat))
                {
                    Model.CourseMaterialTyps.Add(m);
                }
            }

            Model.RatingValue = this._ratingValue;

            courseMgr.Update(Model);
            this.SaveImage = "/Resources/Images/StatusAnnotations_Complete_and_ok_16xLG_color.png";
            this.IsButtonEnabled = false;
        }

        public void ExecuteDeleteCommand(QualificationViewModel quali)
        {
            this.prepared.Remove(quali);
        }

        public void ExecuteMatDeleteCommand(CourseMaterialTypViewModel couseMatTyp)
        {
            this.preparedMat.Remove(couseMatTyp);
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


            if (this.preparedMat == null)
            {
                this.preparedMat = new ObservableCollection<CourseMaterialTypViewModel>();
            }

            foreach (CourseMaterialTypViewModel m in preparedMat)
            {
                if (m.Name == model.Name)
                    return;
            }
            this.preparedMat.Add(model);


        }

        #endregion

        #region helpers
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

        private void CalculatePrice(decimal p)
        {
            decimal grossPrice = p;
            decimal netPrice = decimal.MinValue;
            decimal vat = 19;

            netPrice = grossPrice / ((100 + vat) / 100);
            this.NetAmount = (netPrice * vat / 100);
            this.NetPrice = netPrice;
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

        

        private IList<SealingSchoolWPF.Model.CourseMaterialTyp> prepareMaterialTyps(IList<CourseMaterialTypViewModel> list)
        {
            IList<SealingSchoolWPF.Model.CourseMaterialTyp> matTypList = new List<SealingSchoolWPF.Model.CourseMaterialTyp>();

            foreach (CourseMaterialTypViewModel m in list)
            {
                SealingSchoolWPF.Model.CourseMaterialTyp matTyp = new Model.CourseMaterialTyp();
                matTyp.Id = m.Id;
                matTyp.MaterialTyp = m.MaterialTyp;
                matTyp.Amount = m.MatAmount;
                matTypList.Add(matTyp);
            }

            return matTypList;
        }

        private ObservableCollection<CourseMaterialTypViewModel> preparedMat;
        private ObservableCollection<CourseMaterialTypViewModel> matTypList()
        {
            if (preparedMat == null || preparedMat.Count == 0)
            {
                preparedMat = new ObservableCollection<CourseMaterialTypViewModel>();
            }
            foreach (CourseMaterialTypViewModel q in prepareMatTyps(Model.CourseMaterialTyps))
            {
                preparedMat.Add(q);
            }
            return preparedMat;
        }

        private ObservableCollection<CourseMaterialTypViewModel> prepareMatTyps(ICollection<SealingSchoolWPF.Model.CourseMaterialTyp> collection)
        {
            ObservableCollection<CourseMaterialTypViewModel> list = new ObservableCollection<CourseMaterialTypViewModel>();

            foreach (Model.CourseMaterialTyp q in collection)
            {
                CourseMaterialTypViewModel model = new CourseMaterialTypViewModel(q);
                list.Add(model);
            }

            return list;
        }
        #endregion
    }
}