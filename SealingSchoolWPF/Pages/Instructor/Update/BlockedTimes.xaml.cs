using SealingSchoolWPF.ViewModel.BusinessUnit;
using SealingSchoolWPF.ViewModel.InstructorViewModel;
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

namespace SealingSchoolWPF.Pages.Instructor.Update
{
    /// <summary>
    /// Interaction logic for Qualification.xaml
    /// </summary>
    public partial class BlockedTimes : UserControl
    {
      public BlockedTimes()
        {
            InitializeComponent();
            var viewModel = UpdateInstructorViewModel.Instance;
            this.DataContext = viewModel;
        }

        private void Buttontest_Click( object sender, RoutedEventArgs e )
        {
          var viewModel = UpdateInstructorViewModel.Instance;
          var obj = ( (FrameworkElement) sender ).DataContext as SealingSchoolWPF.ViewModel.Course.BlockedTimesViewModel;
          viewModel.ExecuteDeleteBlockCommand( obj );
        }
    }
}
