using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Material.Update;
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

        MaterialMgr studMgr = new MaterialMgr();

        public string Name
        {
            get
            {
                return MaterialDummy.Name;
            }
            set
            {
                MaterialDummy.Name = value;
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

        public IEnumerable<MaterialStatus> MaterialStatus
        {
            get
            {
                return Enum.GetValues(typeof(MaterialStatus))
                    .Cast<MaterialStatus>();
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
            studMgr.Update(Model);
        }
    }
}