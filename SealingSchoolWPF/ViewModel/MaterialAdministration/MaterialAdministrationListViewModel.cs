using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.MaterialAdministrationViewModel
{
    class MaterialAdministrationListViewModel : ViewModel
    {

        static MaterialAdministrationListViewModel instance = null;
        static readonly object padlock = new object();

        public static MaterialAdministrationListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MaterialAdministrationListViewModel();
                    }
                    return instance;
                }
            }
        }


        private ObservableCollection<MaterialAdministrationViewModel> materials;

        public ObservableCollection<MaterialAdministrationViewModel> Materials
        {
            get
            {
                return materials;
            }
            set
            {
                if (Materials != value)
                {
                    materials = value;
                    this.OnPropertyChanged("Materials");
                }
            }
        }

        public MaterialAdministrationListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Material> mats = matMgr.GetAll();
            materials = new ObservableCollection<MaterialAdministrationViewModel>(mats.Select(p => new MaterialAdministrationViewModel(p)));
        }


    }
}