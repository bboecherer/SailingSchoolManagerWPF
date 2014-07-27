using SailingSchoolWPF.ViewModel.BusinessUnit;
using SailingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SailingSchoolWPF.Pages.Student.Create
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class Qualification : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Qualification"/> class.
        /// </summary>
        public Qualification()
        {
            InitializeComponent();
            var viewModel = CreateStudentViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Buttontest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Buttontest_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = CreateStudentViewModel.Instance;
            var obj = ((FrameworkElement)sender).DataContext as QualificationViewModel;
            viewModel.ExecuteDeleteCommand(obj);
        }
    }
}
