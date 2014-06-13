using SealingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SealingSchoolWPF.Pages.Controls
{
  /// <summary>
  /// Interaction logic for QualificationControl.xaml
  /// </summary>
  public partial class StudentControl : UserControl
  {
    public StudentControl()
    {
      InitializeComponent();
    }

    private void Buttontest_Click( object sender, RoutedEventArgs e )
    {
      var viewModel = CreateTAViewModel.Instance;
      var obj = ( (FrameworkElement) sender ).DataContext as SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel;
      viewModel.ExecuteDeleteCommand( obj );
    }
  }
}
