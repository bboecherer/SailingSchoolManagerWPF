using SailingSchoolWPF.Pages;
using SailingSchoolWPF.Pages.Student.Create;
using SailingSchoolWPF.ViewModel.StudentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.StudentVM
{
    /// <summary>
    /// ViewModel for Student Buttons
    /// @Author Benjamin Böcherer
    /// </summary>
    class StudentButtonViewModel : ViewModel
    {
        #region commands
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
            CreateStudent window = new CreateStudent();
            window.ShowDialog();
        }
        #endregion
    }
}
