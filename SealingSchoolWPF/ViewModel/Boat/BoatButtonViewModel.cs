using SailingSchoolWPF.Pages;
using SailingSchoolWPF.Pages.Boat.Create;
using SailingSchoolWPF.ViewModel.Boat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Boat
{
    /// <summary>
    /// ViewModel for boat buttons
    /// @Author Stefan Müller
    /// </summary>
    class BoatButtonViewModel : ViewModel
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
            CreateBoat window = new CreateBoat();
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
            BoatListViewModel viewModel = BoatListViewModel.Instance;

        }
    }
}
