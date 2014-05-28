﻿using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Courses.Create;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.Course;
using SealingSchoolWPF.ViewModel.Invoicing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SealingSchoolWPF.Pages.Invoicing.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class CreditNoteButtons : UserControl
    {
        public CreditNoteButtons()
        {
            this.InitializeComponent();
            var viewModel = new CreditNoteButtonViewModel();
            this.DataContext = viewModel;
        }


    }
}
