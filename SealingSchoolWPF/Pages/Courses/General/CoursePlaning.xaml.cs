using SealingSchoolWPF.Pages.Courses.Planing;
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
    /// Interaction logic for TrainingsActivities.xaml
    /// </summary>
    public partial class CoursePlaning : UserControl
    {
        public CoursePlaning()
        {
            InitializeComponent();
            BindDataContext();
        }

        private void BindDataContext()
        {
            // TODO: viewModel-Binding
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindDataContext();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateCoursePlaning window = new CreateCoursePlaning();
            window.ShowDialog();
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
