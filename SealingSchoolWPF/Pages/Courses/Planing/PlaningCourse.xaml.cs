using FirstFloor.ModernUI.Windows.Controls;
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
  /// Interaction logic for CreateStudent.xaml
  /// </summary>
  public partial class PlaningCourse : ModernWindow
  {
    UpdateCoursePlaningViewModel viewModel;

    public PlaningCourse( SealingSchoolWPF.Model.CoursePlaning course )
    {
      InitializeComponent();
      viewModel = new UpdateCoursePlaningViewModel( course );
      this.DataContext = viewModel;
    }

    private void ModernWindow_Closed_1( object sender, EventArgs e )
    {
      viewModel.Close();
    }
  }
}
