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
using SealingSchoolWPF.ViewModel.Course;

namespace SealingSchoolWPF.Pages.Courses.Planing
{
  /// <summary>
  /// Interaction logic for CreateNewStudent.xaml
  /// </summary>
  public partial class PlaningPage2 : UserControl
  {
    public PlaningPage2()
    {
      InitializeComponent();
      var viewModel = UpdateCoursePlaningViewModel.Instance;
      this.DataContext = viewModel;
    }

    private void Buttontest_Click( object sender, RoutedEventArgs e )
    {
      var viewModel = UpdateCoursePlaningViewModel.Instance;
      var obj = ( (FrameworkElement) sender ).DataContext as SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel;
      viewModel.ExecuteDeleteCommand( obj );
    }
  }
}
