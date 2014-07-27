using SailingSchoolWPF.Pages;
using SailingSchoolWPF.ViewModel.MaterialAdministrationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.MaterialAdministration
{
    class MaterialAdministrationButtonViewModel : ViewModel
    {
        


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
            MaterialAdministrationListViewModel viewModel = MaterialAdministrationListViewModel.Instance;

        }
    }
}
