﻿using SailingSchoolWPF.Pages.Courses.Create;
using SailingSchoolWPF.Pages.Invoicing.Workflows;
using SailingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Invoicing
{
    /// <summary>
    /// ViewModel for Creditnote buttons
    /// @Author Benjamin Böcherer
    /// </summary>
    class CreditNoteButtonViewModel : ViewModel
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
            CreateCreditNoteWF window = new CreateCreditNoteWF();
            window.ShowDialog();
        }
        #endregion
    }
}
