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

namespace SealingSchoolWPF.Pages.Controls
{
    /// <summary>
    /// Interaction logic for PriceControl.xaml
    /// </summary>
    public partial class CreateMultipleStudentControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultipleStudentControl"/> class.
        /// </summary>
        public CreateMultipleStudentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when [checked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void OnChecked(object sender, RoutedEventArgs e)
        {
            var dummyList = new List<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>();

            var viewModel = CreateMultipleInvoiceViewModel.Instance;
            var gridCell = sender as DataGridCell;

            var parent = VisualTreeHelper.GetParent(gridCell);
            while (parent != null && parent.GetType() != typeof(DataGridRow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            DataGridRow row = parent as DataGridRow;
            var student = row.Item as SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel;


        }
    }
}
