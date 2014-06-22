﻿using SealingSchoolWPF.Pages.Boat.Create;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Boat
{
    public class BoatViewModel : ViewModel<SealingSchoolWPF.Model.Boat>
    {
        public BoatViewModel(SealingSchoolWPF.Model.Boat model)
            : base(model)
        {
        }

        BoatTypMgr boatTypMgr = new BoatTypMgr();

        public string BoatID
        {
            get
            {
                return Model.BoatID.ToString();
            }
            set
            {
                if (BoatID != value)
                {
                    Model.BoatID = Convert.ToInt32(value);
                    this.OnPropertyChanged("BoatID");
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

        private IList<SealingSchoolWPF.Model.BoatTyp> GetBoatTypNames()
        {
            BoatTypNames = new List<SealingSchoolWPF.Model.BoatTyp>();
            foreach (Model.BoatTyp inst in boatTypMgr.GetAll())
            {
                BoatTypNames.Add(inst);
            }
            return BoatTypNames;
        }
        private IList<SealingSchoolWPF.Model.BoatTyp> BoatTypNames;

        public IEnumerable<BoatTyp> BoatTypTypeValues
        {
            get
            {
                return GetBoatTypNames();
            }
        }
        public BoatTyp BoatTyp
        {
            get
            {
                return Model.BoatTyp;
            }
            set
            {
                Model.BoatTyp = value;
                this.OnPropertyChanged("BoatTyp");
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