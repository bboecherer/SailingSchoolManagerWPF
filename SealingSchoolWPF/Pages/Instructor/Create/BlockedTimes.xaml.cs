using SealingSchoolWPF.ViewModel.BusinessUnit;
using SealingSchoolWPF.ViewModel.InstructorViewModel;
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

namespace SealingSchoolWPF.Pages.Instructor.Create
{
    /// <summary>
    /// Interaction logic for Qualification.xaml
    /// </summary>
    public partial class BlockedTimes : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockedTimes"/> class.
        /// </summary>
        public BlockedTimes()
        {
            InitializeComponent();
            var viewModel = CreateInstructorViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the 1 event of the Buttontest_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Buttontest_Click_1(object sender, RoutedEventArgs e)
        {
            var viewModel = CreateInstructorViewModel.Instance;
            var obj = ((FrameworkElement)sender).DataContext as SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel;
            viewModel.ExecuteDeleteBlockCommand(obj);
        }
    }
}
