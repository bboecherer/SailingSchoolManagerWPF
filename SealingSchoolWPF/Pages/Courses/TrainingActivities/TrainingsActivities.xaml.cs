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
using SealingSchoolWPF.Pages.Courses.Workflows;
using SealingSchoolWPF.ViewModel.Course;

namespace SealingSchoolWPF.Pages.TrainingActivities
{
  /// <summary>
  /// Interaction logic for TrainingsActivities.xaml
  /// </summary>
  public partial class TrainingsActivities : UserControl
  {
    public TrainingsActivities()
    {
      InitializeComponent();
      BindDataContext();
    }

    private void Button_Click( object sender, RoutedEventArgs e )
    {
      CreateTrainingActivitiesWF window = new CreateTrainingActivitiesWF();
      window.ShowDialog();
    }

    private void Button_Click_1( object sender, RoutedEventArgs e )
    {
      this.DataContext = null;
      BindDataContext();
    }

    private void DataGrid_MouseDoubleClick( object sender, MouseButtonEventArgs e )
    {

    }

    private void UserControl_IsVisibleChanged( object sender, DependencyPropertyChangedEventArgs e )
    {
      this.DataContext = null;
      BindDataContext();
    }

    private void UserControl_MouseEnter( object sender, MouseEventArgs e )
    {
      this.DataContext = null;
      BindDataContext();
    }

    private void BindDataContext()
    {
      var viewModel = CreateTAViewModel.Instance;
      this.DataContext = viewModel;
    }
  }
}
