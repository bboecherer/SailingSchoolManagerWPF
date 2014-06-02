﻿using SealingSchoolWPF.Model;
using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.MaterialAdministrationViewModel
{
    public class MaterialAdministrationViewModel : ViewModel<SealingSchoolWPF.Model.Material>
    {
        public MaterialAdministrationViewModel(SealingSchoolWPF.Model.Material model)
            : base(model)
        {
        }

        MaterialTypMgr matTypMgr = new MaterialTypMgr();

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
