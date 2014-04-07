﻿using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.StudentViewModel;
using SealingSchoolWPF.ViewModel.StudentVM;
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

namespace SealingSchoolWPF.Pages.Student.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class StudentButtons : UserControl
    {
        public StudentButtons()
        {
            InitializeComponent();
            var viewModel = new StudentButtonViewModel();
            this.DataContext = viewModel;
        }
    }
}