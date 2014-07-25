using SealingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SealingSchoolWPF.Pages.BusinessUnit
{
    /// <summary>
    /// Interaction logic for Qualification.xaml
    /// </summary>
    public partial class Qualification : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Qualification"/> class.
        /// </summary>
        public Qualification()
        {
            InitializeComponent();
            var viewModel = QualificationListViewModel.Instance;
            this.DataContext = viewModel;

        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = QualificationListViewModel.Instance;
            var obj = ((FrameworkElement)sender).DataContext as QualificationViewModel;
            viewModel.ExecuteDeleteCommand(obj.Id);
        }
    }
}
