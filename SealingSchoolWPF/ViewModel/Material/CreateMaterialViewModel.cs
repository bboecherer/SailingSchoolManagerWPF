﻿using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.ViewModel.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Material
{
    public class CreateMaterialViewModel : ViewModel<SailingSchoolWPF.Model.Material>
    {

        public CreateMaterialViewModel(SailingSchoolWPF.Model.Material model)
            : base(model)
        {
        }

        static CreateMaterialViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateMaterialViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateMaterialViewModel(new SailingSchoolWPF.Model.Material());
                    }
                    return instance;
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.OnPropertyChanged("Name");
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

        private MaterialStatus _materialStatus;
        public MaterialStatus MaterialStatus
        {
            get
            {
                return _materialStatus;
            }
            set
            {
                _materialStatus = value;
                this.OnPropertyChanged("MaterialStatus");
            }
        }

        private string _brand;
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                this.OnPropertyChanged("Brand");
            }
        }

        private Decimal _price;
        public Decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
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

        private string _repairaction;
        public string RepairAction
        {
            get
            {
                return _repairaction;
            }
            set
            {
                _repairaction = value;
                this.OnPropertyChanged("RepairAction");
            }
        }
        private string _serialNumber;
        public string SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
                this.OnPropertyChanged("SerialNumber");
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

        private IList<SailingSchoolWPF.Model.MaterialTyp> GetMaterialTypNames()
        {
            MaterialTypNames = new List<SailingSchoolWPF.Model.MaterialTyp>();
            foreach (Model.MaterialTyp inst in matTypMgr.GetAll())
            {
                MaterialTypNames.Add(inst);
            }
            return MaterialTypNames;
        }

        private IList<SailingSchoolWPF.Model.MaterialTyp> MaterialTypNames;

        public IEnumerable<MaterialTyp> MaterialTypTypeValues
        {
            get
            {
                return GetMaterialTypNames();
            }
        }

        private MaterialTyp _materialTyp;
        public MaterialTyp MaterialTyp
        {
            get
            {
                return _materialTyp;
            }
            set
            {
                _materialTyp = value;
                this.OnPropertyChanged("MaterialTyp");
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

        private ObservableCollection<BoatTypViewModel> _boatTyps;
        public ObservableCollection<BoatTypViewModel> BoatTyps
        {
            get
            {
                return _boatTyps;
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

            Application.Current.Windows[1].Close();
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

            SailingSchoolWPF.Model.BoatTyp origBoatType = this.BoatTyp;
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
            this.ReBindDataGrid();
        }

        public void ExecuteDeleteCommand(BoatTypViewModel boatTyp)
        {
            this.dummy.Remove(boatTyp);
            this.ReBindDataGrid();
        }

        private List<BoatTypViewModel> dummy = new List<BoatTypViewModel>();

        private IList<SailingSchoolWPF.Model.BoatTyp> prepareBoatTyps(IList<BoatTypViewModel> list)
        {
            IList<SailingSchoolWPF.Model.BoatTyp> boatTypList = new List<SailingSchoolWPF.Model.BoatTyp>();

            foreach (BoatTypViewModel b in list)
            {
                SailingSchoolWPF.Model.BoatTyp boatTyp = new Model.BoatTyp();
                boatTyp.BoatTypID = b.Id;
                boatTypList.Add(boatTyp);
            }

            return boatTypList;
        }

        private void SaveModelToDatabase()
        {
            Model.Name = this.Name;
            Model.MaterialStatus = this.MaterialStatus;
            Model.Brand = this.Brand;
            Model.Price = this.Price;
            Model.RepairAction = this.RepairAction;
            Model.SerialNumber = this.SerialNumber;
            Model.Currency = this.Currency;
            Model.MaterialTyp = this.MaterialTyp;


            Model.AdditionalInfo = this.Notes;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            if (Model.BoatTyps == null)
            {
                Model.BoatTyps = new List<Model.BoatTyp>();
            }

            foreach (SailingSchoolWPF.Model.BoatTyp q in prepareBoatTyps(dummy))
            {
                Model.BoatTyps.Add(q);
            }

            matMgr.Create(Model);
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
            this.Name = null;
            this.MaterialStatus = MaterialStatus.uneingeschränkt_einsatzbereit;
            this.Brand = null;
            this.Price = 0;
            this.Notes = null;
            this.MaterialTyp = null;
            this.Currency = Currency.EUR;
            this.SerialNumber = null;



        }

        private void ReBindDataGrid()
        {
            if (this._boatTyps != null)
            {
                this._boatTyps.Clear();
            }

            BoatTyps = new ObservableCollection<BoatTypViewModel>(dummy);
        }

        public void Close()
        {
            instance = null;

        }
    }
}