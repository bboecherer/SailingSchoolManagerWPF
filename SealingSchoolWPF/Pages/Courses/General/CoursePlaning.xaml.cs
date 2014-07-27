using SailingSchoolWPF.Pages.Courses.Planing;
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

namespace SailingSchoolWPF.Pages
{
    /// <summary>
    /// Interaction logic for TrainingsActivities.xaml
    /// </summary>
    public partial class CoursePlaning : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursePlaning"/> class.
        /// </summary>
        public CoursePlaning()
        {
            InitializeComponent();
            BindDataContext();
        }

        /// <summary>
        /// Binds the data context.
        /// </summary>
        private void BindDataContext()
        {
            var viewModel = SailingSchoolWPF.ViewModel.Course.CoursePlaningViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            BindDataContext();
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateCoursePlaning window = new CreateCoursePlaning();
            window.ShowDialog();
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
        /// Handles the 1 event of the DataGrid_MouseDoubleClick control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void DataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var course = (SailingSchoolWPF.Model.CoursePlaning)grid.SelectedItem;

            if (course != null)
            {
                PlaningCourse window = new PlaningCourse(course);
                window.ShowDialog();
            }
        }
    }
}
