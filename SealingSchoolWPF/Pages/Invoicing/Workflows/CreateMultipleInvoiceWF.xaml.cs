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
using SealingSchoolWPF.ViewModel.Invoicing;

namespace SealingSchoolWPF.Pages.Invoicing.Workflows
{
  /// <summary>
  /// Interaction logic for CreateTrainingActivitiesWF.xaml
  /// </summary>
  public partial class CreateMultipleInvoiceWF : ModernWindow
  {
    CreateMultipleInvoiceViewModel viewModel;

    public CreateMultipleInvoiceWF()
    {
      InitializeComponent();
      viewModel = CreateMultipleInvoiceViewModel.Instance;
      this.DataContext = viewModel;
    }

    private void ModernWindow_Closing( object sender, System.ComponentModel.CancelEventArgs e )
    {
      viewModel.Close();
    }
  }
}