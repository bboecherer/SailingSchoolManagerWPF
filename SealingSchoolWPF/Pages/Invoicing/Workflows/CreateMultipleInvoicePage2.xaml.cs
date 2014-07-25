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
    /// Interaction logic for CreateTAPage2.xaml
    /// </summary>
    public partial class CreateMultipleInvoicePage2 : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultipleInvoicePage2"/> class.
        /// </summary>
        public CreateMultipleInvoicePage2()
        {
            InitializeComponent();
            var viewModel = CreateMultipleInvoiceViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
