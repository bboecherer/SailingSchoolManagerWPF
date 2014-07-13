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
        UpdateInvoiceViewModel viewModel;

        public UpdateInvoice(SealingSchoolWPF.Model.Invoice invoice)
        {
            InitializeComponent();
            viewModel = new UpdateInvoiceViewModel(invoice);
            this.DataContext = viewModel;
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
