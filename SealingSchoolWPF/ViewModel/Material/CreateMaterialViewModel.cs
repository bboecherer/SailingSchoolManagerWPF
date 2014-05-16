using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.MaterialViewModel
{
    public class CreateMaterialViewModel : ViewModel<SealingSchoolWPF.Model.Material>
    {

        public CreateMaterialViewModel(SealingSchoolWPF.Model.Material model)
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
                        instance = new CreateMaterialViewModel(new SealingSchoolWPF.Model.Material());
                    }
                    return instance;
                }
            }
        }

        MaterialMgr matMgr = new MaterialMgr();
        MaterialTypMgr matTypMgr = new MaterialTypMgr();

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

        public void Close()
        {
            instance = null;

        }
    }
}