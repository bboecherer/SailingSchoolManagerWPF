using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.ViewModel.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Boat
{
    /// <summary>
    /// ViewModel for boat update
    /// @Author Stefan Müller
    /// </summary>
    public class UpdateBoatViewModel : ViewModel<SailingSchoolWPF.Model.Boat>
    {
        public SailingSchoolWPF.Model.Boat BoatDummy { get; set; }

        public UpdateBoatViewModel(SailingSchoolWPF.Model.Boat model)
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
                        instance = new UpdateBoatViewModel(new SailingSchoolWPF.Model.Boat());
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


        public SailingSchoolWPF.Model.BoatTyp BoatTyp
        {
            get
            {
                return BoatDummy.BoatTyp;
            }
            set
            {
                BoatDummy.BoatTyp = value;
                this.OnPropertyChanged("BoatTyp");
                resetSaveButton();
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

 









    }
}