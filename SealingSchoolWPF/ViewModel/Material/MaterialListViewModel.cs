using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Material.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Material
{
    class MaterialListViewModel : ViewModel
    {

        static MaterialListViewModel instance = null;
        static readonly object padlock = new object();

        public static MaterialListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MaterialListViewModel();
                    }
                    return instance;
                }
            }
        }


        private ObservableCollection<MaterialViewModel> materials;

        public ObservableCollection<MaterialViewModel> Materials
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

        public MaterialListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Material> mats = matMgr.GetAll();
            materials = new ObservableCollection<MaterialViewModel>(mats.Select(p => new MaterialViewModel(p)));
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
            CreateMaterial window = new CreateMaterial();
            window.ShowDialog();
        }


    }
}