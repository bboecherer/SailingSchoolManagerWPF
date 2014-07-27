using SailingSchoolWPF.Pages.Courses.Create;
using SailingSchoolWPF.Pages.Courses.Workflows;
using SailingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for TA buttons
    /// @Author Benjamin Böcherer
    /// </summary>
    class TaButtonViewModel : ViewModel
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
            CreateTrainingActivitiesWF window = new CreateTrainingActivitiesWF();
            window.ShowDialog();
        }
        #endregion
    }
}
