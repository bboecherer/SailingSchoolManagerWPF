﻿using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.ViewModel.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Boat
{
    public class UpdateBoatViewModel : ViewModel<SealingSchoolWPF.Model.Boat>
    {
        public SealingSchoolWPF.Model.Boat BoatDummy { get; set; }
        BoatMgr boatMgr = new BoatMgr();
        BoatTypMgr boatTypMgr = new BoatTypMgr();

        public UpdateBoatViewModel(SealingSchoolWPF.Model.Boat model)
            : base(model)
        {
            instance = this;
            this.BoatDummy = model;
        }

        static UpdateBoatViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateBoatViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateBoatViewModel(new SealingSchoolWPF.Model.Boat());
                    }
                    return instance;
                }
            }
        }



        public string Name
        {
            get
            {
                return BoatDummy.Name;
            }
            set
            {
                BoatDummy.Name = value;
                resetSaveButton();
                this.OnPropertyChanged("Name");
            }
        }

        public string Brand
        {
            get
            {
                return BoatDummy.Brand;
            }
            set
            {
                BoatDummy.Brand = value;
                resetSaveButton();
                this.OnPropertyChanged("Brand");
            }
        }

        public Decimal Price
        {
            get
            {
                return BoatDummy.Price;
            }
            set
            {
                BoatDummy.Price = value;
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
                return BoatDummy.Currency;
            }
            set
            {
                BoatDummy.Currency = value;
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
                return BoatDummy.MaterialStatus;
            }
            set
            {
                BoatDummy.MaterialStatus = value;
                resetSaveButton();
                this.OnPropertyChanged("MaterialStatus");
            }
        }
        public string RepairAction
        {
            get
            {
                return BoatDummy.RepairAction;
            }
            set
            {
                if (RepairAction != value)
                {
                    BoatDummy.RepairAction = value;
                    resetSaveButton();
                    this.OnPropertyChanged("RepairAction");
                }
            }
        }

        public string SerialNumber
        {
            get
            {
                return BoatDummy.SerialNumber;
            }
            set
            {
                if (SerialNumber != value)
                {
                    BoatDummy.SerialNumber = value;
                    resetSaveButton();
                    this.OnPropertyChanged("SerialNumber");
                }
            }
        }
        
        public string Notes
        {
            get
            {
                return BoatDummy.AdditionalInfo;
            }
            set
            {
                BoatDummy.AdditionalInfo = value;
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
            boatMgr.Update(Model);
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

       

        

        
       

       
    }
}