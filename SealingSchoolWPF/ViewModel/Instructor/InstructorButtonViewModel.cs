using SailingSchoolWPF.Pages.Courses.Create;
using SailingSchoolWPF.Pages.Instructor.Create;
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
    /// ViewModel for instructor buttons
    /// @Author Benjamin Böcherer
    /// </summary>
    class InstructorButtonViewModel : ViewModel
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
            CreateInstructor window = new CreateInstructor();
            window.ShowDialog();
        }
        #endregion
    }
}
