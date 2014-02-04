using De.SealingSchool.ViewModel;
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

namespace De.SealingSchool.StartApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupBindings();
        }

        /// <summary>
        /// prüft, ob die Anwendung beendet werden kann
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }


        /// <summary>
        /// Handler für das Beenden der Anwendung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
           
            this.Close();
        }

        private void SetupBindings()
        {
            var viewModel1 = new StudentListViewModel();
            studentListView.DataContext = viewModel1;

            var viewModel2 = new CourseListViewModel();
            courseListView.DataContext = viewModel2;

            var viewModel3 = new InstructorListViewModel();
            instructorListView.DataContext = viewModel3;
        }
    }
}
