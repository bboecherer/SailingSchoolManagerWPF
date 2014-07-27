using SailingSchoolWPF.Pages.Courses.Update;
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

namespace SailingSchoolWPF.Pages.Courses.General
{
    /// <summary>
    /// Interaction logic for InstructorListView.xaml
    /// </summary>
    public partial class CourseListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseListView"/> class.
        /// </summary>
        public CourseListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the DataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var course = (SailingSchoolWPF.ViewModel.Course.CourseViewModel)grid.SelectedItem;

            if (course != null)
            {
                UpdateCourse window = new UpdateCourse(course);
                window.ShowDialog();
            }
        }
    }
}
