﻿using SailingSchoolWPF.Data;
using SailingSchoolWPF.Pages.Instructor.Create;
using SailingSchoolWPF.Pages.Student.Create;
using SailingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SailingSchoolWPF.Pages.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class Buttons : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Buttons"/> class.
        /// </summary>
        public Buttons()
        {
            InitializeComponent();
            var viewModel = CreateStudentViewModel.Instance;
            this.DataContext = viewModel;
        }

    }
}
