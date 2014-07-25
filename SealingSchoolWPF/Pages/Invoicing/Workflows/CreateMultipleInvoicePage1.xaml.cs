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
    /// Interaction logic for CreateTAPage1.xaml
    /// </summary>
    public partial class CreateMultipleInvoicePage1 : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultipleInvoicePage1"/> class.
        /// </summary>
        public CreateMultipleInvoicePage1()
        {
            InitializeComponent();
            var viewModel = CreateMultipleInvoiceViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
