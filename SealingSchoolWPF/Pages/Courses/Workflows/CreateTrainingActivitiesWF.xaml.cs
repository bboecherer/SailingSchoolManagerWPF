﻿using FirstFloor.ModernUI.Windows.Controls;
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
using SealingSchoolWPF.ViewModel.Course;
namespace SealingSchoolWPF.Pages.Courses.Workflows
{
  /// <summary>
  /// Interaction logic for CreateTrainingActivitiesWF.xaml
  /// </summary>
  public partial class CreateTrainingActivitiesWF : ModernWindow
  {
    CreateTAViewModel viewModel;

    public CreateTrainingActivitiesWF()
    {
      InitializeComponent();
      viewModel = CreateTAViewModel.Instance;
      this.DataContext = viewModel;
    }

    private void ModernWindow_Closing( object sender, System.ComponentModel.CancelEventArgs e )
    {
      viewModel.Close();
    }
  }
}
