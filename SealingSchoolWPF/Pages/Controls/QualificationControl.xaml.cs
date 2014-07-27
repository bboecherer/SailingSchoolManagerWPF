using SailingSchoolWPF.ViewModel.BusinessUnit;
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
using SailingSchoolWPF.ViewModel.Course;

namespace SailingSchoolWPF.Pages.Controls
{
    /// <summary>
    /// Interaction logic for QualificationControl.xaml
    /// </summary>
    public partial class QualificationControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QualificationControl"/> class.
        /// </summary>
        public QualificationControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Buttontest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Buttontest_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = CreateCourseViewModel.Instance;
            var obj = ((FrameworkElement)sender).DataContext as QualificationViewModel;
            viewModel.ExecuteDeleteCommand(obj);
        }
    }
}
