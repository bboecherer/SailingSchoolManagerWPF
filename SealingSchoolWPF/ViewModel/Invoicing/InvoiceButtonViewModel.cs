﻿using SealingSchoolWPF.Pages.Courses.Create;
using SealingSchoolWPF.Pages.Invoicing.Workflows;
using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Invoicing
{
    class InvoiceButtonViewModel : ViewModel
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
            CreateInvoiceWF window = new CreateInvoiceWF();
            window.ShowDialog();
        }
    }
}