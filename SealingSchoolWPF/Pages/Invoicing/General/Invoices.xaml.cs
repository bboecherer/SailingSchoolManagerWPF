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
using SealingSchoolWPF.Pages.Invoicing.Workflows;
using SealingSchoolWPF.ViewModel.Invoicing;
using SealingSchoolWPF.Pages.Invoicing.Update;

namespace SealingSchoolWPF.Pages
{
    /// <summary>
    /// Interaction logic for Invoices.xaml
    /// </summary>
    public partial class Invoices : UserControl
    {
        public Invoices()
        {
            InitializeComponent();
            BindViewModel();
        }

        public void BindViewModel()
        {
            this.DataContext = null;
            var viewModel = CreateInvoiceViewModel.Instance;
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoiceWF window = new CreateInvoiceWF();
            window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateMultipleInvoiceWF window = new CreateMultipleInvoiceWF();
            window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BindViewModel();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var invoice = (SealingSchoolWPF.Model.Invoice)grid.SelectedItem;

            if (invoice != null)
            {
                UpdateInvoice window = new UpdateInvoice(invoice);
                window.ShowDialog();
            }
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindViewModel();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BindViewModel();
        }
    }
}
