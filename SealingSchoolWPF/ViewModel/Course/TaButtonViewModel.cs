using SealingSchoolWPF.Pages.Courses.Create;
using SealingSchoolWPF.Pages.Courses.Workflows;
using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Course
{
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
