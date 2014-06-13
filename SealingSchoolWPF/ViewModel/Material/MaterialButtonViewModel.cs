using SealingSchoolWPF.Pages;
using SealingSchoolWPF.Pages.Material.Create;
using SealingSchoolWPF.ViewModel.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Material
{
    class MaterialButtonViewModel : ViewModel
    {
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


        private ICommand refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                if (refreshCommand == null)
                {
                    refreshCommand = new RelayCommand(p => ExecuteRefreshCommand());
                }
                return refreshCommand;
            }
        }

        private void ExecuteRefreshCommand()
        {
            MaterialListViewModel viewModel = MaterialListViewModel.Instance;

        }
    }
}
