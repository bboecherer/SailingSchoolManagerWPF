using SealingSchoolWPF.Pages.Courses.Create;
using SealingSchoolWPF.ViewModel.Course;
using SealingSchoolWPF.ViewModel.Instructor;
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

namespace SealingSchoolWPF.Pages.Courses.General
{
    /// <summary>
    /// Interaction logic for Instructors.xaml
    /// </summary>
    public partial class CourseView : UserControl
    {
        public CourseView()
        {
            InitializeComponent();
            var viewModel = new CourseListViewModel();
            courseList.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new CourseListViewModel();
            courseList.DataContext = null;
            courseList.DataContext = viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateCourse window = new CreateCourse();
            window.ShowDialog();
        }
    }
}
