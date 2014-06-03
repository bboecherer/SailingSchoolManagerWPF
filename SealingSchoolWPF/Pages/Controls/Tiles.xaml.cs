﻿using System;
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
using SealingSchoolWPF.ViewModel.General;

namespace SealingSchoolWPF.Pages.Controls
{
  /// <summary>
  /// Interaction logic for Tiles.xaml
  /// </summary>
  public partial class Tiles : UserControl
  {
    public Tiles()
    {
      InitializeComponent();
      var viewModel = new LiveTilesViewModel();
      this.DataContext = viewModel;
    }

    private void UserControl_IsVisibleChanged( object sender, DependencyPropertyChangedEventArgs e )
    {
      this.DataContext = null;
      var viewModel = new LiveTilesViewModel();
      this.DataContext = viewModel;
    }
  }
}
