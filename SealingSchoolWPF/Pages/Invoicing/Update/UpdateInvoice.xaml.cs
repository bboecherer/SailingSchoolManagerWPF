using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.ViewModel.Course;
using SealingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SealingSchoolWPF.Pages.Invoicing.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateInvoice : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateInvoiceViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvoice"/> class.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public UpdateInvoice(SealingSchoolWPF.Model.Invoice invoice)
        {
            InitializeComponent();
            viewModel = new UpdateInvoiceViewModel(invoice);
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Closing event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
