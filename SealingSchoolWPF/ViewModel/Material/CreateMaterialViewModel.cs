using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Material.Create;
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

        private decimal _price;
        public decimal Price
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
        private string _documents;
        public string Documents
        {
            get
            {
                return _documents;
            }
            set
            {
                _documents = value;
                this.OnPropertyChanged("Documents");
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
            
            Model.Name = this.Name;
            Model.MaterialStatus = this.MaterialStatus;
            Model.Brand = this.Brand;
            Model.Price = this.Price;
            Model.RepairAction = this.RepairAction;
            Model.SerialNumber = this.SerialNumber;
            Model.Currency = this.Currency;
            

            Model.AdditionalInfo = this.Notes ;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
            

            matMgr.Create(Model);

            this.IsButtonEnabled = false;
            this.ImageSourceSave = "/Resources/Images/StatusAnnotations_Complete_and_ok_32xLG_color.png";
            this.ImageSourceClear = "";
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
            
        }

        public void Close()
        {
            instance = null;

        }
    }
}