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
using SealingSchoolWPF.ViewModel.Course;

namespace SealingSchoolWPF.Pages.Course.Workflows
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class CreatePlaningPage1 : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlaningPage1"/> class.
        /// </summary>
        public CreatePlaningPage1()
        {
            InitializeComponent();
            var viewModel = CreateCoursePlaningViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the LostFocus event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = CreateCoursePlaningViewModel.Instance;
            viewModel.CheckFields();
        }

        /// <summary>
        /// Handles the IsVisibleChanged event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = CreateCoursePlaningViewModel.Instance;
            viewModel.CheckFields();
        }
    }
}
