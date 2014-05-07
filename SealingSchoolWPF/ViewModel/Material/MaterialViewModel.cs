using SealingSchoolWPF.Pages.Material.Create;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.MaterialViewModel
{
    public class MaterialViewModel : ViewModel<SealingSchoolWPF.Model.Material>
    {
        public MaterialViewModel(SealingSchoolWPF.Model.Material model)
            : base(model)
        {
        }

        public string Id
        {
            get
            {
                return Model.MaterialId.ToString();
            }
            set
            {
                if (Id != value)
                {
                    Model.MaterialId = Convert.ToInt32(value);
                    this.OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                if (Name != value)
                {
                    Model.Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        public string Brand
        {
            get
            {
                return Model.Brand;
            }
            set
            {
                Model.Brand = value;
                this.OnPropertyChanged("Brand");
            }
        }

        public decimal Price
        {
            get
            {
                return Model.Price;
            }
            set
            {
                Model.Price = value;
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
                return Model.Currency;
            }
            set
            {
                Model.Currency = value;
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
                return Model.MaterialStatus;
            }
            set
            {
                Model.MaterialStatus = value;
                this.OnPropertyChanged("MaterialStatus");
            }
        }

        public IEnumerable<MaterialType> MaterialTypeTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(MaterialType))
                    .Cast<MaterialType>();
            }
        }
        public MaterialType MaterialType
        {
            get
            {
                return Model.MaterialType;
            }
            set
            {
                Model.MaterialType = value;
                this.OnPropertyChanged("MaterialType");
            }
        }

        public string RepairAction
        {
            get
            {
                return Model.RepairAction;
            }
            set
            {
                if (RepairAction != value)
                {
                    Model.RepairAction = value;
                    this.OnPropertyChanged("RepairAction");
                }
            }
        }
        public string SerialNumber
        {
            get
            {
                return Model.SerialNumber;
            }
            set
            {
                if (SerialNumber != value)
                {
                    Model.SerialNumber = value;
                    this.OnPropertyChanged("SerialNumber");
                }
            }
        }
        public string Notes
        {
            get
            {
                return Model.AdditionalInfo;
            }
            set
            {
                Model.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return Model.CreatedOn ?? DateTime.MinValue; ;
            }
            set
            {
                if (CreatedOn != value)
                {
                    Model.CreatedOn = value;
                    this.OnPropertyChanged("CreatedOn");
                }
            }
        }

        public DateTime ModifiedOn
        {
            get
            {
                return Model.ModifiedOn ?? DateTime.MinValue; ;
            }
            set
            {
                if (ModifiedOn != value)
                {
                    Model.ModifiedOn = value;
                    this.OnPropertyChanged("ModifiedOn");
                }
            }
        }
    }
}
