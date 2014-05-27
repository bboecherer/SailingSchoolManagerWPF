using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SealingSchoolWPF.Pages.Student.General
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        public StudentView()
        {
            InitializeComponent();
            var viewModel = new StudentListViewModel();
            studentList.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindDataContext();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateStudent window = new CreateStudent();
            window.ShowDialog();
        }

        private void BindDataContext()
        {
            var viewModel = new StudentListViewModel();
            studentList.DataContext = null;
            studentList.DataContext = viewModel;
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
