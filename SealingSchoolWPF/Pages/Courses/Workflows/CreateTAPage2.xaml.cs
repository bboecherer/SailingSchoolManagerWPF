﻿using SealingSchoolWPF.ViewModel.CourseViewModel;
using System;
using System.Collections.Generic;
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

namespace SealingSchoolWPF.Pages.Courses.Workflows
{
    /// <summary>
    /// Interaction logic for CreateTAPage2.xaml
    /// </summary>
    public partial class CreateTAPage2 : UserControl
    {
        public CreateTAPage2()
        {
            InitializeComponent();
            var viewModel = CreateTAViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
