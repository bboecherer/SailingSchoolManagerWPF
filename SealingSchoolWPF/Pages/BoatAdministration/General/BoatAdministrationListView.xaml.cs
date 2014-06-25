﻿using SealingSchoolWPF.Pages.BoatAdministration.Administration;
using SealingSchoolWPF.ViewModel.BoatAdministrationViewModel;
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

namespace SealingSchoolWPF.Pages
{
  /// <summary>
  /// Interaction logic for MaterialListView.xaml
  /// </summary>
  public partial class BoatAdministrationListView : UserControl
  {
    public BoatAdministrationListView()
    {
      InitializeComponent();
    }

    private void DataGrid_MouseDoubleClick( object sender, MouseButtonEventArgs e )
    {
      var grid = sender as DataGrid;
      var boat = (SealingSchoolWPF.ViewModel.BoatAdministrationViewModel.BoatAdministrationViewModel) grid.SelectedItem;

      if ( boat != null )
      {
        AdministrateBoat window = new AdministrateBoat( boat );
        window.ShowDialog();
      }
    }
  }
}
