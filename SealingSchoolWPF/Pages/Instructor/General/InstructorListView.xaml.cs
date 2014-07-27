using SailingSchoolWPF.Pages.Instructor.Update;
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
    /// Interaction logic for InstructorListView.xaml
    /// </summary>
    public partial class InstructorListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorListView"/> class.
        /// </summary>
        public InstructorListView()
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
            var instructor = (SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel)grid.SelectedItem;

            if (instructor != null)
            {
                UpdateInstructor window = new UpdateInstructor(instructor);
                window.ShowDialog();
            }
        }
    }
}
