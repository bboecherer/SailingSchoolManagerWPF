﻿using SealingSchoolWPF.Pages.Courses.Create;
using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Course
{
    class CourseButtonViewModel : ViewModel
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
            CreateCourse window = new CreateCourse();
            window.ShowDialog();
        }
        #endregion
    }
}
