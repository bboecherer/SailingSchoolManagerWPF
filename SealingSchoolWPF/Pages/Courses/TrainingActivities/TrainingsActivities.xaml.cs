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
using SailingSchoolWPF.Pages.Courses.Workflows;
using SailingSchoolWPF.ViewModel.Course;

namespace SailingSchoolWPF.Pages.TrainingActivities
{
    /// <summary>
    /// Interaction logic for TrainingsActivities.xaml
    /// </summary>
    public partial class TrainingsActivities : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingsActivities"/> class.
        /// </summary>
        public TrainingsActivities()
        {
            InitializeComponent();
            BindDataContext();
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTrainingActivitiesWF window = new CreateTrainingActivitiesWF();
            window.ShowDialog();
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            BindDataContext();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the DataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// Handles the IsVisibleChanged event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.DataContext = null;
            BindDataContext();
        }

        /// <summary>
        /// Handles the MouseEnter event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.DataContext = null;
            BindDataContext();
        }

        /// <summary>
        /// Binds the data context.
        /// </summary>
        private void BindDataContext()
        {
            var viewModel = CreateTAViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
