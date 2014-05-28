using SealingSchoolWPF.Pages.Instructor.Create;
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

namespace SealingSchoolWPF.Pages.General
{
    /// <summary>
    /// Interaction logic for Instructors.xaml
    /// </summary>
    public partial class Instructors : UserControl
    {
        public Instructors()
        {
            InitializeComponent();
            var viewModel = new InstructorListViewModel();

            instructorList.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindDataContext();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateInstructor window = new CreateInstructor();
            window.ShowDialog();
        }

        private void BindDataContext()
        {
            var viewModel = new InstructorListViewModel();
            instructorList.DataContext = null;
            instructorList.DataContext = viewModel;
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindDataContext();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BindDataContext();
        }
    }
}
