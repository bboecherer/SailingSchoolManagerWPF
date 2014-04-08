using SealingSchoolWPF.Pages.Instructor.Update;
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

namespace SealingSchoolWPF.Pages
{
    /// <summary>
    /// Interaction logic for InstructorListView.xaml
    /// </summary>
    public partial class InstructorListView : UserControl
    {
        public InstructorListView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var instructor = (SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel)grid.SelectedItem;

            UpdateInstructor window = new UpdateInstructor(instructor);
            window.ShowDialog();
        }
    }
}
