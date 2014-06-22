﻿using SealingSchoolWPF.ViewModel.BoatAdministrationViewModel;
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

namespace SealingSchoolWPF.Pages.BoatAdministration.General
{
    /// <summary>
    /// Interaction logic for MaterialView.xaml
    /// </summary>
    public partial class BoatAdministrationView : UserControl
    {
        public BoatAdministrationView()
        {
            InitializeComponent();
            var viewModel = new BoatAdministrationListViewModel();
            boatAdministrationList.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new BoatAdministrationListViewModel();
            boatAdministrationList.DataContext = null;
            boatAdministrationList.DataContext = viewModel;
        }

      
    }
}