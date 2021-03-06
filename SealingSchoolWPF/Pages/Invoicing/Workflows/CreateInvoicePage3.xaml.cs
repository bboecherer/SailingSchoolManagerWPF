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
using SailingSchoolWPF.ViewModel.Invoicing;

namespace SailingSchoolWPF.Pages.Invoicing.Workflows
{
    /// <summary>
    /// Interaction logic for CreateTAPage3.xaml
    /// </summary>
    public partial class CreateInvoicePage3 : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoicePage3"/> class.
        /// </summary>
        public CreateInvoicePage3()
        {
            InitializeComponent();
            var viewModel = CreateInvoiceViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
