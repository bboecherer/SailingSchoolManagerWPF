﻿using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.Pages.MaterialAdministration.Administration;
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

namespace SailingSchoolWPF.ViewModel.MaterialAdministrationViewModel
{
    public class UpdateMaterialAdministrationViewModel : ViewModel<SailingSchoolWPF.Model.Material>
    {
        public SailingSchoolWPF.Model.Material MaterialDummy { get; set; }

        public UpdateMaterialAdministrationViewModel(SailingSchoolWPF.Model.Material model)
            : base(model)
        {
            instance = this;
            this.MaterialDummy = model;
        }

        static UpdateMaterialAdministrationViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateMaterialAdministrationViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateMaterialAdministrationViewModel(new SailingSchoolWPF.Model.Material());
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

        public decimal Price
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
            matMgr.Update(Model);
            this.IsButtonEnabled = false;
            this.ImageSourceSave = "/Resources/Images/StatusAnnotations_Complete_and_ok_32xLG_color.png";

        }

        private void resetSaveButton()
        {
            this.IsButtonEnabled = true;
            this.ImageSourceSave = "/Resources/Images/save_16xLG.png";

        }
    }
}