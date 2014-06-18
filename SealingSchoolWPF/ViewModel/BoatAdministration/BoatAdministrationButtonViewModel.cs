using SealingSchoolWPF.Pages;
using SealingSchoolWPF.ViewModel.BoatAdministrationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.BoatAdministration
{
    class BoatAdministrationButtonViewModel : ViewModel
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
            BoatAdministrationListViewModel viewModel = BoatAdministrationListViewModel.Instance;

        }
    }
}
