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
using SailingSchoolWPF.Pages.Invoicing.Workflows;
using SailingSchoolWPF.ViewModel.Invoicing;
using SailingSchoolWPF.Pages.Invoicing.Update;

namespace SailingSchoolWPF.Pages
{
    /// <summary>
    /// Interaction logic for Invoices.xaml
    /// </summary>
    public partial class Invoices : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoices"/> class.
        /// </summary>
        public Invoices()
        {
            InitializeComponent();
            BindViewModel();
        }

        /// <summary>
        /// Binds the view model.
        /// </summary>
        public void BindViewModel()
        {
            this.DataContext = null;
            var viewModel = CreateInvoiceViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoiceWF window = new CreateInvoiceWF();
            window.ShowDialog();
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateMultipleInvoiceWF window = new CreateMultipleInvoiceWF();
            window.ShowDialog();
        }

        /// <summary>
        /// Handles the 2 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BindViewModel();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the DataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var invoice = (SailingSchoolWPF.Model.Invoice)grid.SelectedItem;

            if (invoice != null)
            {
                UpdateInvoice window = new UpdateInvoice(invoice);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the IsVisibleChanged event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindViewModel();
        }

        /// <summary>
        /// Handles the MouseEnter event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BindViewModel();
        }
    }
}
