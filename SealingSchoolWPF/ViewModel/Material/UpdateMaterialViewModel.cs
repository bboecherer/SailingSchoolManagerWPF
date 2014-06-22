using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.ViewModel.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Material
{
    public class UpdateMaterialViewModel : ViewModel<SealingSchoolWPF.Model.Material>
    {
        public SealingSchoolWPF.Model.Material MaterialDummy { get; set; }
        
        public UpdateMaterialViewModel(SealingSchoolWPF.Model.Material model)
            : base(model)
        {
            instance = this;
            this.MaterialDummy = model;
        }

        static UpdateMaterialViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateMaterialViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateMaterialViewModel(new SealingSchoolWPF.Model.Material());
                    }
                    return instance;
                }
            }
        }



        public string Name
        {
            get
            {
                return MaterialDummy.Name;
            }
            set
            {
                MaterialDummy.Name = value;
                resetSaveButton();
                this.OnPropertyChanged("Name");
            }
        }

        public string Brand
        {
            get
            {
                return MaterialDummy.Brand;
            }
            set
            {
                MaterialDummy.Brand = value;
                resetSaveButton();
                this.OnPropertyChanged("Brand");
            }
        }

        public Decimal Price
        {
            get
            {
                return MaterialDummy.Price;
            }
            set
            {
                MaterialDummy.Price = value;
                resetSaveButton();
                this.OnPropertyChanged("Price");
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
                return MaterialDummy.Currency;
            }
            set
            {
                MaterialDummy.Currency = value;
                resetSaveButton();
                this.OnPropertyChanged("Currency");
            }
        }
        public IEnumerable<MaterialStatus> MaterialStatusTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(MaterialStatus))
                    .Cast<MaterialStatus>();
            }
        }
        public MaterialStatus MaterialStatus
        {
            get
            {
                return MaterialDummy.MaterialStatus;
            }
            set
            {
                MaterialDummy.MaterialStatus = value;
                resetSaveButton();
                this.OnPropertyChanged("MaterialStatus");
            }
        }
        public string RepairAction
        {
            get
            {
                return MaterialDummy.RepairAction;
            }
            set
            {
                if (RepairAction != value)
                {
                    MaterialDummy.RepairAction = value;
                    resetSaveButton();
                    this.OnPropertyChanged("RepairAction");
                }
            }
        }

        public string SerialNumber
        {
            get
            {
                return MaterialDummy.SerialNumber;
            }
            set
            {
                if (SerialNumber != value)
                {
                    MaterialDummy.SerialNumber = value;
                    resetSaveButton();
                    this.OnPropertyChanged("SerialNumber");
                }
            }
        }
        private IList<SealingSchoolWPF.Model.MaterialTyp> GetMaterialTypNames()
        {
            MaterialTypNames = new List<SealingSchoolWPF.Model.MaterialTyp>();
            foreach (Model.MaterialTyp inst in matTypMgr.GetAll())
            {
                MaterialTypNames.Add(inst);
            }
            return MaterialTypNames;
        }
        private IList<SealingSchoolWPF.Model.MaterialTyp> MaterialTypNames;

        public IEnumerable<MaterialTyp> MaterialTypTypeValues
        {
            get
            {
                return GetMaterialTypNames();
            }
        }
        public MaterialTyp MaterialTyp
        {
            get
            {
                return MaterialDummy.MaterialTyp;
            }
            set
            {
                MaterialDummy.MaterialTyp = value;
                this.OnPropertyChanged("MaterialTyp");
            }
        }
        public string Notes
        {
            get
            {
                return MaterialDummy.AdditionalInfo;
            }
            set
            {
                MaterialDummy.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
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
            Model.BoatTyps.Clear();
            if (dummy != null)
            {
                foreach (BoatTypViewModel q in dummy)
                {
                    
                    Model.BoatTyps.Add(prepareBoatTypToSave(q));
                }
            }
            matMgr.Update(Model);
            this.IsButtonEnabled = false;
            this.ImageSourceSave = "/Resources/Images/StatusAnnotations_Complete_and_ok_32xLG_color.png";

        }

        private void resetSaveButton()
        {
            this.IsButtonEnabled = true;
            this.ImageSourceSave = "/Resources/Images/save_16xLG.png";

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

        private SealingSchoolWPF.Model.BoatTyp _boatTyp;
        public SealingSchoolWPF.Model.BoatTyp BoatTyp
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

        private ObservableCollection<BoatTypViewModel> _boatTyps;
        public ObservableCollection<BoatTypViewModel> BoatTyps
        {
            get
            {
                return boatTypList();
            }
            set
            {
                if (BoatTyps != value)
                {
                    _boatTyps = value;
                    this.OnPropertyChanged("BoatTyps");
                }
            }
        }
        private ICommand addBoatTypCommand;
        public ICommand AddBoatTypCommand
        {
            get
            {
                if (addBoatTypCommand == null)
                {
                    addBoatTypCommand = new RelayCommand(p => ExecuteAddBoatTypCommand());
                }
                return addBoatTypCommand;
            }
        }

        private void ExecuteAddBoatTypCommand()
        {
            if (this.BoatTyp == null)
                return;

            SealingSchoolWPF.Model.BoatTyp origBoatType = this.BoatTyp;
            BoatTypViewModel boatTyp = new BoatTypViewModel(origBoatType);
            if (this._boatTyps == null)
            {
                this._boatTyps = new ObservableCollection<BoatTypViewModel>();
            }

            foreach (BoatTypViewModel b in dummy)
            {
                if (b.Name == boatTyp.Name)
                    return;
            }

            this.dummy.Add(boatTyp);

           
        }

        public void ExecuteDeleteCommand(BoatTypViewModel boatTyp)
        {
            this.dummy.Remove(boatTyp);
           
        }

       

        private IList<SealingSchoolWPF.Model.BoatTyp> prepareBoatTyps(IList<BoatTypViewModel> list)
        {
            IList<SealingSchoolWPF.Model.BoatTyp> boatTypList = new List<SealingSchoolWPF.Model.BoatTyp>();

            foreach (BoatTypViewModel b in list)
            {
                SealingSchoolWPF.Model.BoatTyp boatTyp = new Model.BoatTyp();
                boatTyp.BoatTypID = b.Id;
                boatTypList.Add(boatTyp);
            }

            return boatTypList;
        }

        private void ReBindDataGrid()
        {
            if (this._boatTyps != null)
            {
                this._boatTyps.Clear();
            }

            BoatTyps = new ObservableCollection<BoatTypViewModel>(dummy);
        }

        private ObservableCollection<BoatTypViewModel> dummy;
        private ObservableCollection<BoatTypViewModel> boatTypList()
        {
            if (dummy == null || dummy.Count == 0)
            {
                dummy = new ObservableCollection<BoatTypViewModel>();
            }
            foreach (BoatTypViewModel q in prepareBoatTyps(Model.BoatTyps))
            {
                dummy.Add(q);
            }
            return dummy;
        }

        private ObservableCollection<BoatTypViewModel> prepareBoatTyps(ICollection<SealingSchoolWPF.Model.BoatTyp> collection)
        {
            ObservableCollection<BoatTypViewModel> list = new ObservableCollection<BoatTypViewModel>();

            if (collection != null)
            {
                foreach (Model.BoatTyp q in collection)
                {
                    BoatTypViewModel model = new BoatTypViewModel(q);
                    list.Add(model);
                }
            }

            return list;
        }

        private SealingSchoolWPF.Model.BoatTyp prepareBoatTypToSave(BoatTypViewModel b)
        {
            SealingSchoolWPF.Model.BoatTyp boatTyp = new Model.BoatTyp();
            boatTyp.BoatTypID = b.Id;
            return boatTyp;
        }
    }
}